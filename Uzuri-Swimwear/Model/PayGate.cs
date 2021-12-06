using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Security.Cryptography;
using System.Configuration;
using Uzuri_Swimwear.Model;
using System.Data.Entity.Core.Objects;
using System.Threading.Tasks;

namespace Uzuri_Swimwear.Model
{
    public class PayGate
    {
        //urls and keys
        public string UrlInitiate { get; } = "https://secure.paygate.co.za/payweb3/initiate.trans";
        public string UrlRedirect { get; } = "https://secure.paygate.co.za/payweb3/process.trans";
        public string UrlQuery { get; } = "https://secure.paygate.co.za/payweb3/query.trans";
        public string PayGateID { get; } = ConfigurationManager.AppSettings["PAYGATEID"];
        public string PayGateKey { get; } = ConfigurationManager.AppSettings["PAYGATEKEY"];


        public PayGate()
        {

        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// method to encode the url call to a string, this creates the URL call to use for paygate
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public string ToUrlEncodedString(Dictionary<string, string> request)
        {
            StringBuilder builder = new StringBuilder();

            foreach (var key in request.Keys)
            {
                builder.Append("&");
                builder.Append(key);
                builder.Append("=");
                builder.Append(HttpUtility.UrlEncode(request[key]));
            }

            string result = builder.ToString().TrimStart('&'); //gets rid of the starting & for the url
            return result;
        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// turn the response into a dictionary, decode URL string
        /// </summary>
        /// <param name="response"></param>
        /// <returns></returns>
        public Dictionary<string, string> toDictionary(string response)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            //break down the url returned 
            string[] valuePairs = response.Split('&');
            foreach (string pair in valuePairs)
            {
                string[] values = pair.Split('=');
                result.Add(values[0], HttpUtility.UrlDecode(values[1]));
            }
            return result;
        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// method to add returned transaction to the database
        /// </summary>
        /// <param name="request"></param>
        /// <param name="payRequestId"></param>
        /// <returns></returns>
        public async Task AddTransaction(Dictionary<string, string> request, decimal amount, string payRequestId)
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    int orderID = Convert.ToInt32(request["REFERENCE"]);
                    var query = dbContext.AddTransaction(payRequestId, amount, orderID);
                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to get the orderID, for querying API upon transaction completion
        /// </summary>
        /// <returns></returns>
        public int GetOrder(string payRequestId)
        {
            int oID = 0;
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    ObjectParameter orderID = new ObjectParameter("orderID", typeof(int));
                    dbContext.GetOrderId(payRequestId, orderID);
                    oID = Convert.ToInt32(orderID.Value);
                    return oID;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return oID;
            }
        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Method to update the transaction upon query request 
        /// </summary>
        /// <param name="request"></param>
        /// <param name="payRequestId"></param>
        public void UpdateTransaction(Dictionary<string, string> request, string payRequestId)
        {
            try
            {
                using (var dbContext = new UzuriSwimwearDBEntities())
                {
                    int resultNum = Convert.ToInt32(request["RESULT_CODE"]);
                    string resultDesc = request["RESULT_DESC"];
                    dbContext.UpdateTransaction(payRequestId, resultNum, resultDesc);
                    dbContext.SaveChanges();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Result codes returned from PayGate
        /// </summary>
        public enum ResultCodes
        {
            Call_for_Approval = 900001,
            Card_Expired = 900002,
            Insufficient_Funds = 900003,
            Invalid_Card_Number = 900004,
            Bank_Interface_Timeout = 900005,
            Invalid_Card = 900006,
            Declined = 900007,
            Lost_Card = 900009,
            Invalid_Card_Length = 900010,
            Suspected_Fraud = 900011,
            Card_Reported_as_Stolen = 900012,
            Restricted_Card = 900013,
            Excessive_Card_Usage = 900014,
            Card_Blacklisted = 900015,
            Declined_Authentication_failed = 900207,
            Auth_Declined = 990020,
            ThreeD_Secure_Lookup_Timeout = 900210,
            Invalid_expiry_date = 991001,
            Invalid_amount = 991002
        }
        #region MD5 Hashing
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Create the MD5 hash for security purposes with paygate
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encryptionKey"></param>
        /// <returns></returns>
        public string GetMd5Hash(Dictionary<string, string> data, string encryptionKey)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                StringBuilder input = new StringBuilder();
                foreach (string value in data.Values)
                {
                    input.Append(value);
                }

                input.Append(encryptionKey);

                byte[] hash = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input.ToString()));

                StringBuilder sBuilder = new StringBuilder();

                for (int i = 0; i < hash.Length; i++)
                {
                    sBuilder.Append(hash[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// verify the hash on return, compares the CHECKSUMS
        /// </summary>
        /// <param name="data"></param>
        /// <param name="encryptionKey"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool VerifyMd5Hash(Dictionary<string, string> data, string encryptionKey, string hash)
        {
            Dictionary<string, string> hashDict = new Dictionary<string, string>();

            foreach (string key in data.Keys)
            {
                if (key != "CHECKSUM")
                {
                    hashDict.Add(key, data[key]);
                }
            }

            string hashOfInput = GetMd5Hash(hashDict, encryptionKey);

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion MD5 Hash
    }
}