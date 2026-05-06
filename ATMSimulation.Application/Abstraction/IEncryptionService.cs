namespace ATMSimulation.Application.Abstraction;
public interface IEncryptionService
{
    string Encrypt(string plainText);
    string Decrypt(string cipherText);
}