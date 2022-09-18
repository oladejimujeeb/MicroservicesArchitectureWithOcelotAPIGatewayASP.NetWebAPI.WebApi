using NUnit.Framework;
using Product.Microservice.Implementation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace MicroServices.UnitTest
{
    [TestFixture]
    public class HtmlFomaterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_EncloseStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("ABC");

            //specific Test
            Assert.That(result, Is.EqualTo("<strong>ABC</strong>"));

            // General Test
            Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("ABC"));
        }
    }
}
