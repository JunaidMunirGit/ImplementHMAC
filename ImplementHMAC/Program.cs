using System;
using System.Security.Cryptography;
using System.Text;

class Program
{
    static void Main()
    {

        //For secure communcation between two parties we can use this idea


        var secretKey = Encoding.UTF8.GetBytes("my_secret_key");
        var message = "Hello World, This is a message for demo woking on HMAC";
        var messageBytes = Encoding.UTF8.GetBytes(message);

        using (var hmac = new HMACSHA256(secretKey))
        {
            // Generating the HMAC signature
            var signature = hmac.ComputeHash(messageBytes);
            var signatureString = Convert.ToBase64String(signature);
            Console.WriteLine($"Signature: {signatureString}");

            // Verifying the HMAC signature
            var computedSignature = hmac.ComputeHash(messageBytes);
            var computedSignatureString = Convert.ToBase64String(computedSignature);
            bool isValid = signatureString == computedSignatureString;
            Console.WriteLine($"Is Valid: {isValid}");
        }
    }
}
