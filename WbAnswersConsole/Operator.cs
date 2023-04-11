using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Org.BouncyCastle.Asn1.X500;

namespace WbAnswersConsole
{
    internal class Operator
    {
        public Random rnd = new Random();
        public const string Phone = "9375253753";
        public const string CommUrl = "https://portal-cc.wildberries.ru/COMMUNICATION";
        public const string GetCd = "//custom-button[contains(@class, 'login-button')]";
        public const string phoneInputPath = "//input[contains(@class, 'input-element')]";

        public Operator(IAnswerProvider answerProvider) 
        {
            AnswerProvider = answerProvider;
        }

        private IAnswerProvider AnswerProvider { get; }

        public void StartJob()
        {
            // Авторизация
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(CommUrl);
            Thread.Sleep(2000);

            List<IWebElement> phEnter = driver.FindElements(By.XPath(phoneInputPath)).ToList();
            if(phEnter.Count > 0)
            {
                IWebElement ph = phEnter.FirstOrDefault();
                ph.Click();

                Console.WriteLine("Вписываем телефон");
                for (int i = 0; i < Phone.Length; i++)
                {
                    ph.SendKeys(Phone[i].ToString());
                    Thread.Sleep(rnd.Next(400, 700));
                }

                // Получить код
                List<IWebElement> getCode = driver.FindElements(By.XPath(GetCd)).ToList();
                if (getCode.Count > 0)
                {
                    IWebElement cd = getCode.FirstOrDefault();
                    cd.Click();
                }
            }

            while (true)
            {

            }
        }
    }
}
