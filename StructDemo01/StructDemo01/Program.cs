// See https://aka.ms/new-console-template for more information
using StructDemo01;

Resolution hdResolution = new(1920, 1080);
var cinemaSolution = hdResolution;
cinemaSolution.Width = 2048;
Console.WriteLine($"HD Resolution is {hdResolution.Width} pixels wide and {hdResolution.Height} pixels high");
Console.WriteLine($"CinemaResolution is {cinemaSolution.Width} picels wide and {cinemaSolution.Height} pixels high");

/*VideoMode someVideoMode = new();

Console.WriteLine(someVideoMode.Resolution);*/