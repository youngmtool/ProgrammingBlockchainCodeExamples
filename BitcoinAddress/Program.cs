using System;
using System.Linq;
using System.Runtime.InteropServices;
using NBitcoin;
using NBitcoin.DataEncoders;

// ReSharper disable All

namespace BitcoinAddress
{
    class Program
    {
        static void Main()
        {
           RandomUtils.Random = new UnsecureRandom();
            //===========================================================================================
            //Part3. Bitcoin transfer

            //===========================================================================================
            //Chapter1. Bitcoin address

            //===========================================================================================
            //Section1. Bitcoin address

            //Generate a random private key.
            Key privateKey = new Key();
            Console.WriteLine($"privateKey: {privateKey.ToString(Network.Main)}");
            
            //From the private key, we use a one-way cryptographic function, to generate a public key.
            PubKey publicKey = privateKey.PubKey;
            Console.WriteLine($"publicKey: {publicKey}");
            
            Console.WriteLine(privateKey.GetBitcoinSecret(Network.Main).PubKey.GetType());



            //===========================================================================================
            //Section2. Dive into more details of "new Key()", a private key, a public key.

            //Yes, it is a key object. If you print a privateKey variable by:
            Console.WriteLine(privateKey);

            
            //============================================================================================
            //Section3. Bitcoin network and Bitcoin address

            Console.WriteLine(publicKey.GetAddress(Network.Main));
            Console.WriteLine(publicKey.GetAddress(Network.TestNet));
            
            //The above illustration shows a standard way of generating a Bitcoin address by processing entire steps(Public key -> Public key hash +Network => Bitcoin address), with not using a sugar syntax for generating a Bitcoin address(Public key + Network => Bitcoin address).
            var publicKeyHash = publicKey.Hash;
            Console.WriteLine(publicKeyHash);
            
            //Get a Bitcoin address for a mainnet by publicKeyHash and network identifier.
            var mainNetAddress = publicKeyHash.GetAddress(Network.Main);
            var testNetAddress = publicKeyHash.GetAddress(Network.TestNet);
            Console.WriteLine(mainNetAddress);
            Console.WriteLine(testNetAddress);


            //============================================================================================
            //Section4. Encoding schemes
            
            //The Base58Check encoding scheme also provides a consistent way to determine the network of a given address, which means that this feature prevents a wallet from sending MainNet coins to a TestNet address.
            var bitcoinAddressForMainNet = privateKey.PubKey.GetAddress(Network.Main);
            var bitcoinAddressForTestNet = privateKey.PubKey.GetAddress(Network.TestNet);

            //Get the consistent network type from the specific Bitcoin address.
            var mainNetFromBitcoinAddress = bitcoinAddressForMainNet.Network;
            var testNetFromBitcoinAddress = bitcoinAddressForTestNet.Network;
            Console.WriteLine($"mainNetFromBitcoinAddress: {mainNetFromBitcoinAddress}");
            Console.WriteLine($"testNetFromBitcoinAddress: {testNetFromBitcoinAddress}");
            
            Console.ReadLine();
        }
    }
}
