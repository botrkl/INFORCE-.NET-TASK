using test_Console;

PasswordHashingService testHash = new PasswordHashingService();

string hashedPass  = testHash.HashPassword("qwerty");

Console.WriteLine(hashedPass);

//aB0EdSxRiHlAvb2jhh4mwg==:DkK9EhrV+D/P26+nNpEl71Z6nsX/FzY6nCNZ6RXISBg=

var result = testHash.VerifyPassword("qwerty", "OsHojmUdhbfCY23K6zzjGA==:ocRB/6EZ6fHcFfWwYCvUkHtyycglKdkTKrDGLaic+CQ=");
Console.WriteLine(result);

result = testHash.VerifyPassword("qwerty", "aB0EdSxRiHlAvb2jhh4mwg==:DkK9EhrV+D/P26+nNpEl71Z6nsX/FzY6nCNZ6RXISBg=");
Console.WriteLine(result);

result = testHash.VerifyPassword("qwerty", hashedPass);
Console.WriteLine(result);