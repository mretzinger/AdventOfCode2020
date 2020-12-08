using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace AdventOfCode.Days
{
    public class Four
    {
        public void Run()
        {
            List<PassportInfo> passportInfos = Parse();
            Console.WriteLine("Day 4 Problem 1 Answer: " + Day4Prob1(passportInfos));
            Console.WriteLine("Day 4 Problem 2 Answer: " + Day4Prob2(passportInfos));
        }

        public List<PassportInfo> Parse()
        {
            string line;
            List<PassportInfo> passportInfos = new List<PassportInfo>();
            StreamReader file = new StreamReader("C:\\Users\\Margaret Landefeld\\MyProjects\\AdventOfCode\\Days\\Four\\Data.txt");
            IDictionary<string, string> passDictionary = new Dictionary<string, string>();

            while ((line = file.ReadLine()) != null)
            {
                line = line.Trim();
                if (line == "")
                {
                    passportInfos.Add(new PassportInfo(passDictionary));
                    passDictionary = new Dictionary<string, string>();
                    continue;
                }

                string[] data = line.Split(' ');
                foreach(var item in data)
                {
                    passDictionary.Add(item.Split(':')[0], item.Split(':')[1]);
                }
            }
            passportInfos.Add(new PassportInfo(passDictionary));
            return passportInfos;
        }

        static private int Day4Prob1(List<PassportInfo> passportInfos)
        {
            //Day 4 answer 1 = 191
            int finalSum = 0;
            foreach (var item in passportInfos)
            {
                if (PassportValidator.Validate(item))
                {
                    finalSum++;
                }
            }

            return finalSum;
        }

        static private int Day4Prob2(List<PassportInfo> passportInfos)
        {
            //Day 4 Answer 2 = 101
            int finalSum = 0;

            foreach (var item in passportInfos)
            {
                if(PassportValidator.ValidateAll(item))
                {
                    finalSum++;
                }
            }

            return finalSum;
        }

    }

    public class PassportValidator
    {
        public static bool Validate(PassportInfo info)
        {
            
            return !String.IsNullOrEmpty(info.BirthYear) && 
                !String.IsNullOrEmpty(info.IssueYear) && 
                !String.IsNullOrEmpty(info.ExpirationYear) &&
                !String.IsNullOrEmpty(info.Height) &&
                !String.IsNullOrEmpty(info.HairColor) &&
                !String.IsNullOrEmpty(info.EyeColor) &&
                !String.IsNullOrEmpty(info.PassportID);
        }

        public static bool ValidateAll(PassportInfo info)
        {
            return ValidateBirthYear(info) &&
                ValidateIssueYear(info) &&
                ValidateExpirationYear(info) &&
                ValidateHeight(info) &&
                ValidateHairColor(info) &&
                ValidateEyeColor(info) &&
                ValidatePassportID(info);
        }

        public static bool ValidateBirthYear(PassportInfo info)
        {
            return !String.IsNullOrEmpty(info.BirthYear) &&
                info.BirthYear.Length == 4 &&
                int.Parse(info.BirthYear) >= 1920 &&
                int.Parse(info.BirthYear) <= 2002;
        }

        public static bool ValidateIssueYear(PassportInfo info)
        {

            return !String.IsNullOrEmpty(info.IssueYear) &&
                info.IssueYear.Length == 4 &&
                int.Parse(info.IssueYear) >= 2010 &&
                int.Parse(info.IssueYear) <= 2020;
        }

        public static bool ValidateExpirationYear(PassportInfo info)
        {

            return !String.IsNullOrEmpty(info.ExpirationYear) &&
                info.IssueYear.Length == 4 &&
                int.Parse(info.ExpirationYear) >= 2020 &&
                int.Parse(info.ExpirationYear) <= 2030;
        }

        public static bool ValidateHeight(PassportInfo info)
        {

            return !String.IsNullOrEmpty(info.Height) &&
                (info.Height.Contains("cm") ?
                (int.Parse(info.Height.Split('c')[0]) >= 150 && int.Parse(info.Height.Split('c')[0]) <= 193) :
                info.Height.Contains("in") ?
                (int.Parse(info.Height.Split('i')[0]) >= 59 && int.Parse(info.Height.Split('i')[0]) <= 76) :
                false);
        }

        public static bool ValidateHairColor(PassportInfo info)
        {
            Regex rx = new Regex("^#(?:[0-9a-fA-F]{6})$");
            return !String.IsNullOrEmpty(info.HairColor) && rx.IsMatch(info.HairColor);

        }

        public static bool ValidateEyeColor(PassportInfo info)
        {
            if(!String.IsNullOrEmpty(info.EyeColor))
            {
                return info.EyeColor == "amb" || info.EyeColor == "blu" || info.EyeColor == "brn" ||
                info.EyeColor == "gry" || info.EyeColor == "grn" || info.EyeColor == "hzl" || info.EyeColor == "oth";
            }
            return false;
        }

        public static bool ValidatePassportID(PassportInfo info)
        {

            return !String.IsNullOrEmpty(info.PassportID) &&
                info.PassportID.Length == 9;
        }
    }


    public class PassportInfo
    {
        public PassportInfo(IDictionary<string, string> data)
        {
            BirthYear = data.ContainsKey("byr") ? data["byr"] : "";
            IssueYear = data.ContainsKey("iyr") ? data["iyr"] : "";
            ExpirationYear = data.ContainsKey("eyr") ? data["eyr"] : "";
            Height = data.ContainsKey("hgt") ? data["hgt"] : "";
            HairColor = data.ContainsKey("hcl") ? data["hcl"] : "";
            EyeColor = data.ContainsKey("ecl") ? data["ecl"] : "";
            PassportID = data.ContainsKey("pid") ? data["pid"] : "";
            CountryID = data.ContainsKey("cid") ? data["cid"] : "";
        }

        public string BirthYear { get; set; }
        public string IssueYear { get; set; }
        public string ExpirationYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportID { get; set; }
        public string CountryID { get; set; }
    }
}
