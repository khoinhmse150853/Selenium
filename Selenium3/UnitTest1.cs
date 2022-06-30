using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium3
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        //Kiểm tra coi ô input có bị null hay ko
        [Test]
        public void TestInputIsNull()
        {
            //Tạo 1 driver để chạy web trên trình duyệt Chrome
            IWebDriver driver = new ChromeDriver();
            //Truyền đường dẫn của trang cần chạy để test
            driver.Navigate().GoToUrl("http://localhost:8432/");
            //Tìm những thuộc tính có trên web theo Id rồi đưa giá trị mà muốn kiểm tra vào (Id của các thẻ html trong trang index.cshtml bên QuadraticEquation)
            driver.FindElement(By.Id("a")).SendKeys("");
            driver.FindElement(By.Id("b")).SendKeys("");
            driver.FindElement(By.Id("c")).SendKeys("");
            //Tìm những thuộc tính có trên web theo Id rồi nhấn nút click
            driver.FindElement(By.Id("btnGet")).Click();
            //Kết quả thực hiện được lấy từ ô kết quả 
            string actual = driver.FindElement(By.Id("result")).Text;
            //expected là kết quả người test mong muốn
            string expected = "Vui lòng điền đầy đủ";
            //So sánh 2 kết quả
            Assert.AreEqual(actual, expected);
            //Đóng trình duyệt (nếu đúng)
            driver.Close();
        }

        //Kiểm tra coi ô input có nhập đúng số hay ko
        [Test]
        public void TestInputIsNumber()
        {
            //Tạo 1 driver để chạy web trên trình duyệt Chrome
            IWebDriver driver = new ChromeDriver();
            //Truyền đường dẫn của trang cần chạy để test
            driver.Navigate().GoToUrl("http://localhost:8432/");
            //Tìm những thuộc tính có trên web theo Id rồi đưa giá trị mà muốn kiểm tra vào (Id của các thẻ html trong trang index.cshtml bên QuadraticEquation)
            driver.FindElement(By.Id("a")).SendKeys("a");
            driver.FindElement(By.Id("b")).SendKeys("2");
            driver.FindElement(By.Id("c")).SendKeys("6");
            //Tìm những thuộc tính có trên web theo Id rồi nhấn nút click
            driver.FindElement(By.Id("btnGet")).Click();
            //Kết quả thực hiện được lấy từ ô kết quả 
            string actual = driver.FindElement(By.Id("result")).Text;
            //expected là kết quả người test mong muốn
            string expected = "Vui lòng nhập số";
            //So sánh 2 kết quả
            Assert.AreEqual(actual, expected);
            //Đóng trình duyệt (nếu đúng)
            driver.Close();
        }

        //Kiểm tra nếu phương trình có 2 nghiệm phân biệt
        [Test]
        public void TestTwoDiscriminateSolutions()
        {
            //Tạo 1 driver để chạy web trên trình duyệt Chrome
            IWebDriver driver = new ChromeDriver();
            //Truyền đường dẫn của trang cần chạy để test
            driver.Navigate().GoToUrl("http://localhost:8432/");
            //Tìm những thuộc tính có trên web theo Id rồi đưa giá trị mà muốn kiểm tra vào (Id của các thẻ html trong trang index.cshtml bên QuadraticEquation)
            driver.FindElement(By.Id("a")).SendKeys("2");
            driver.FindElement(By.Id("b")).SendKeys("-7");
            driver.FindElement(By.Id("c")).SendKeys("3");
            //Tìm những thuộc tính có trên web theo Id rồi nhấn nút click
            driver.FindElement(By.Id("btnGet")).Click();
            //Kết quả thực hiện được lấy từ ô kết quả 
            string actual = driver.FindElement(By.Id("result")).Text;
            //expected là kết quả người test mong muốn
            string expected = "Phương trình có hai nghiệm phân biệt x1 = 3; x2 = 0,5";
            //So sánh 2 kết quả
            Assert.AreEqual(actual, expected);
            //Đóng trình duyệt (nếu đúng)
            driver.Close();
        }

        //Kiểm tra nếu phương trình có nghiệm kép
        [Test]
        public void TestTwoSameSolutions()
        {
            //Tạo 1 driver để chạy web trên trình duyệt Chrome
            IWebDriver driver = new ChromeDriver();
            //Truyền đường dẫn của trang cần chạy để test
            driver.Navigate().GoToUrl("http://localhost:8432/");
            //Tìm những thuộc tính có trên web theo Id rồi đưa giá trị mà muốn kiểm tra vào (Id của các thẻ html trong trang index.cshtml bên QuadraticEquation)
            driver.FindElement(By.Id("a")).SendKeys("1");
            driver.FindElement(By.Id("b")).SendKeys("-4");
            driver.FindElement(By.Id("c")).SendKeys("4");
            //Tìm những thuộc tính có trên web theo Id rồi nhấn nút click
            driver.FindElement(By.Id("btnGet")).Click();
            //Kết quả thực hiện được lấy từ ô kết quả 
            string actual = driver.FindElement(By.Id("result")).Text;
            //expected là kết quả người test mong muốn
            string expected = "Phương trình có nghiệm kép x1 = x2 = 2";
            //So sánh 2 kết quả
            Assert.AreEqual(actual, expected);
            //Đóng trình duyệt (nếu đúng)
            driver.Close();
        }

        //Kiểm tra nếu phương trình có vô nghiệm khi delta < 0
        [Test]
        public void TestNoSolutionWithDelta()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:8432/");
            driver.FindElement(By.Id("a")).SendKeys("1");
            driver.FindElement(By.Id("b")).SendKeys("2");
            driver.FindElement(By.Id("c")).SendKeys("4");
            driver.FindElement(By.Id("btnGet")).Click();
            string actual = driver.FindElement(By.Id("result")).Text;
            string expected = "Phương trình vô nghiệm";
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        //Kiểm tra phương trình có vô số nghiệm
        [Test]
        public void TestMultipleSolutions()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:8432/");
            driver.FindElement(By.Id("a")).SendKeys("0");
            driver.FindElement(By.Id("b")).SendKeys("0");
            driver.FindElement(By.Id("c")).SendKeys("0");
            driver.FindElement(By.Id("btnGet")).Click();
            string actual = driver.FindElement(By.Id("result")).Text;
            string expected = "Phương trình có vô số nghiệm";
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        //Kiểm tra phương trình có vô nghiệm khi a = 0, b = 0 và c != 0
        [Test]
        public void TestNoSolution()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:8432/");
            driver.FindElement(By.Id("a")).SendKeys("0");
            driver.FindElement(By.Id("b")).SendKeys("0");
            driver.FindElement(By.Id("c")).SendKeys("2");
            driver.FindElement(By.Id("btnGet")).Click();
            string actual = driver.FindElement(By.Id("result")).Text;
            string expected = "Phương trình vô nghiệm";
            Assert.AreEqual(actual, expected);
            driver.Close();
        }

        //Kiểm tra phương trình có 1 nghiệm khi a = 0
        [Test]
        public void TestASolutionWithAIsZero()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:8432/");
            driver.FindElement(By.Id("a")).SendKeys("0");
            driver.FindElement(By.Id("b")).SendKeys("4");
            driver.FindElement(By.Id("c")).SendKeys("4");
            driver.FindElement(By.Id("btnGet")).Click();
            string actual = driver.FindElement(By.Id("result")).Text;
            string expected = "Phương trình có nghiệm duy nhất x1 = -1";
            Assert.AreEqual(actual, expected);
            driver.Close();
        }
    }
}