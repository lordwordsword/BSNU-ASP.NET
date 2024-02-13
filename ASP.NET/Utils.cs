using Microsoft.Extensions.Configuration;
using System.Text.RegularExpressions;
using System;

public class Utils
{
	public static IConfigurationRoot LoadConfiguration(string filename)
	{
        var configuration = new ConfigurationBuilder();
        string dir = Environment.CurrentDirectory;
        if (Regex.IsMatch(filename, @"\.(json)$"))
        {
            configuration.AddJsonFile(dir +"\\"+ filename);
        }
        else if (Regex.IsMatch(filename, @"\.(xml)$"))
        {
            configuration.AddXmlFile(dir + "\\" + filename);
        }
        else if(Regex.IsMatch(filename, @"\.(ini)$"))
        {
            configuration.AddIniFile(dir + "\\" + filename);
        }
        return configuration.Build();
	}
    public static string CompanyWithTheMostEmployees(IConfigurationRoot config, int len)
    {
        //тут теж я хотів написати більш-менш універсальний код,
        //але не знаю як визначити кількість елементів у секції, 
        //тому передаю len окремим параметром

        int max_value = -1;
        string company_name = "";
        for (int i =0; i < len; i++)
        {
            int new_value = config.GetSection($"Companies:{i}:employees").Get<int>();
            Console.WriteLine(new_value);
            if (new_value > max_value)
            {
                max_value = new_value;
                company_name = config.GetSection($"Companies:{i}:name").Get<string>();
            }
        }
        if (company_name is null)
        {
            return "Something going wrong";
        }
        return company_name;
    }
}
