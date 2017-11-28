using System;
using NBitcoin;
// ReSharper disable All

namespace PrivateKey
{
    class Program
    {
        static void Main()
        {
            //==========================================================================================
            //Chapter4. Private key

            RandomUtils.Random = new UnsecureRandom();


            //Generate one random private key.
            //Key privateKey = new Key();

            //Create a private key by the hardcode value to get consistent result from every execution.
            BitcoinSecret bitcoinSecretForThisExample = new BitcoinSecret("L5DZpEdbDDhhk3EqtktmGXKv3L9GxttYTecxDhM5huLd82qd9uvo", Network.Main);
            Key privateKey = bitcoinSecretForThisExample.PrivateKey;
            

            //Generate a Bitcoin secret for the MainNet, which is nothing but a private key represented in Base58Check binary-to-text encoding scheme.
            BitcoinSecret privateKeyForMainNet = privateKey.GetBitcoinSecret(Network.Main);
            //Generate a Bitcoin secret for the TestNet, which is nothing but a private key represented in Base58Check binary-to-text encoding scheme.
            BitcoinSecret privateKeyForTestNet = privateKey.GetBitcoinSecret(Network.TestNet);
           
            Console.WriteLine($"privateKeyForMainNet: {privateKeyForMainNet}");
            Console.WriteLine($"privateKeyForTestNet: {privateKeyForTestNet}");
            


            //You can also generate a private key by invoking GetWif() on the private key by additionally specifying a network identifier.
            //Note that we're using the same private key generated from above.
            BitcoinSecret privateKeyByGetWifMethod = privateKey.GetWif(Network.Main);
            Console.WriteLine(privateKeyByGetWifMethod);

            bool wifIsPrivateKey = privateKeyForMainNet == privateKey.GetWif(Network.Main);
            Console.WriteLine(wifIsPrivateKey);
            

            //Get the Bitcoin secret by invoking GetWif() on the private key with passing additionally the network identifier.
            BitcoinSecret bitcoinSecretByGetWif = privateKey.GetWif(Network.Main);
            //Get the Bitcoin secret by invoking GetBitcoinSecret() on the private key with passing additionally the network identifier.
            BitcoinSecret bitcoinSecretByGetBitcoinSecret = privateKey.GetBitcoinSecret(Network.Main);

            //Get the private key from the Bitcoin secret.
            var privateKeyFromBsByGetWif = bitcoinSecretByGetWif.PrivateKey;
            var privateKeyFromBsByGetBitcoinSecret = bitcoinSecretByGetBitcoinSecret.PrivateKey;


            Console.WriteLine($"privateKeyFromBsByGetWif: {privateKeyFromBsByGetWif.ToString(Network.Main)}");
            Console.WriteLine($"privateKeyFromBsByGetBitcoinSecret: {privateKeyFromBsByGetBitcoinSecret.ToString(Network.Main)}");
            
            Console.WriteLine(privateKey==privateKeyFromBsByGetWif);


            PubKey publicKey = privateKey.PubKey;
            BitcoinPubKeyAddress bitcoinAddress = publicKey.GetAddress(Network.Main);
            Console.WriteLine($"bitcoinAddress: {bitcoinAddress}");
            

            //But it is impossible to get a public key from a Bitcoin address.
            //PubKey publicKeyFromBitcoinAddress = bitcoinAddress.ItIsNotPossible;

            Console.ReadLine();
        }
    }
}
