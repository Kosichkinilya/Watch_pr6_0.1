using System;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

namespace Watch_pr6_kosichkin_0._1;

class Program : MauiApplication
{
	protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

	static void Main(string[] args)
	{
		var app = new Program();
		app.Run(args);
	}
}
