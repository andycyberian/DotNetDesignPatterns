using V1 = Bridge.V1;
using V2 = Bridge.V2;

DateTime now = DateTime.Now;
var noDiscount = new V1.NoDiscount();
var license1 = new V1.TwoDaysLicense("Secret Life of Pets", now, noDiscount);
var license2 = new V1.LifeLongLicense("Matrix", now, noDiscount);

PrintLicenseDetails(license1);
PrintLicenseDetails(license2);

var militaryDiscount = new V1.MilitaryDiscount();
var seniorDiscount = new V1.SeniorDiscount();
var license3 = new V1.TwoDaysLicense("Secret Life of Pets", now, militaryDiscount);
var license4 = new V1.LifeLongLicense("Matrix", now, seniorDiscount);

PrintLicenseDetails(license3);
PrintLicenseDetails(license4);



var license5 = new V2.MovieLicense("Secret Life of Pets", now, V2.Discount.None, V2.LicenceType.TwoDays);
var license6 = new V2.MovieLicense("Matrix", now, V2.Discount.None, V2.LicenceType.LifeLong);

PrintV2LicenseDetails(license5);
PrintV2LicenseDetails(license6);

var license7 = new V2.MovieLicense("Secret Life of Pets", now, V2.Discount.Military, V2.LicenceType.LifeLong);
var license8 = new V2.MovieLicense("Matrix", now, V2.Discount.Senior, V2.LicenceType.TwoDays);

PrintV2LicenseDetails(license7);
PrintV2LicenseDetails(license8);

var license9 = new V2.MovieLicense("Matrix", now, V2.Discount.Senior, V2.LicenceType.TwoDays, V2.SpecialOffer.TwoDaysExtension);

PrintV2LicenseDetails(license9);


Console.ReadKey();


static void PrintLicenseDetails(V1.MovieLicense license)
{
    Console.WriteLine($"Movie: {license.Movie}");
    Console.WriteLine($"Price: {GetPrice(license)}");
    Console.WriteLine($"Valid for: {GetValidFor(license)}");

    Console.WriteLine();
}

static void PrintV2LicenseDetails(V2.MovieLicense license)
{
    Console.WriteLine($"Movie: {license.Movie}");
    Console.WriteLine($"Price: {GetV2Price(license)}");
    Console.WriteLine($"Valid for: {GetV2ValidFor(license)}");

    Console.WriteLine();
}


static string GetPrice(V1.MovieLicense license)
{
    return $"${license.GetPrice():0.00}";
}

static string GetV2Price(V2.MovieLicense license)
{
    return $"${license.GetPrice():0.00}";
}


static string GetValidFor(V1.MovieLicense license)
{
    DateTime? expirationDate = license.GetExpirationDate();

    if (expirationDate == null)
        return "Forever";

    TimeSpan timeSpan = expirationDate.Value - DateTime.Now;

    return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
}
static string GetV2ValidFor(V2.MovieLicense license)
{
    DateTime? expirationDate = license.GetExpirationDate();

    if (expirationDate == null)
        return "Forever";

    TimeSpan timeSpan = expirationDate.Value - DateTime.Now;

    return $"{timeSpan.Days}d {timeSpan.Hours}h {timeSpan.Minutes}m";
}
