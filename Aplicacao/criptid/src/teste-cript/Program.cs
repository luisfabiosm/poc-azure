
using criptid.Account;
using criptid.App;

Console.WriteLine("Teste, Crip!");

AppEncriptor _appEncript = new AppEncriptor();

var _token = _appEncript.GetAppSecret("1.0.0","agendamento");

Console.WriteLine($"App Token: {_token}");

AccountEncriptor _accEncript = new AccountEncriptor();


int agency = 123;
int number = 456789;
int accType = 3;


var _id = _accEncript.GetAccountID(agency,number,accType, _token);

Console.WriteLine($"Encrypted ID: {_id}");

var (decryptedAgency, decryptedAccount, decryptedAccType) = _accEncript.GetAccount(_id, accType, _token);


Console.WriteLine($"Decrypted Agency: {decryptedAgency}, Account: {decryptedAccount}, AccType: {decryptedAccType}");

Console.ReadLine();
