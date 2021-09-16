// Extrauppgift

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace MethodsAndLists.Test
{
    [TestClass]
    public class AddNumberEngineTests
    {
        [TestMethod]
        public void should_add_numbers_between_three_and_six()
        {
            // (happy path)
            var x = new AddNumberEngine();
            x.Input("3");
            x.Input("6");
            int result = x.Result();
            Assert.AreEqual(3 + 4 + 5 + 6, result);
        }

        [TestMethod]
        public void should_handle_inputs_that_are_not_number()
        {
            var x = new AddNumberEngine();

            ExpectException(AddNumberEngine.Error.InputIsNotNumber, () => x.Input(null));
            ExpectException(AddNumberEngine.Error.InputIsNotNumber, () => x.Input(""));
            ExpectException(AddNumberEngine.Error.InputIsNotNumber, () => x.Input("a"));
            x.Input("3");
            ExpectException(AddNumberEngine.Error.InputIsNotNumber, () => x.Input("b"));
            x.Input("6");
            ExpectException(AddNumberEngine.Error.InputIsNotNumber, () => x.Input("c"));
            ExpectException(AddNumberEngine.Error.InputIsNotNumber, () => x.Input(null));
            int result = x.Result();
            Assert.AreEqual(3 + 4 + 5 + 6, result);
        }

        [TestMethod]
        public void handle_if_result_is_called_too_early()
        {
            var x = new AddNumberEngine();

            ExpectException(AddNumberEngine.Error.DontHaveTwoValues, () => x.Result());
            x.Input("3");

            ExpectException(AddNumberEngine.Error.DontHaveTwoValues, () => x.Result());
            x.Input("6");

            int result = x.Result();
            Assert.AreEqual(3 + 4 + 5 + 6, result);
        }

        [TestMethod]
        public void handle_if_two_values_already_is_supplied()
        {
            var x = new AddNumberEngine();
            x.Input("3");
            x.Input("6");
            ExpectException(AddNumberEngine.Error.AlreadyHaveTwoValues, () => x.Input("9"));
            int result = x.Result();
            Assert.AreEqual(3 + 4 + 5 + 6, result);
        }


        [TestMethod]
        public void handle_if_second_value_is_lower_than_the_first_number()
        {
            var x = new AddNumberEngine();
            x.Input("3");
            ExpectException(AddNumberEngine.Error.SecondValueCantBeLowerThanFirst, () => x.Input("2"));

            x.Input("6");

            int result = x.Result();
            Assert.AreEqual(3 + 4 + 5 + 6, result);
        }

        private void ExpectException(AddNumberEngine.Error expectedError, Action action)
        {
            try
            {
                action();
                Assert.Fail();
            }
            catch (AddNumberEngine.Exception ex)
            {
                Assert.AreEqual(expectedError, ex.Error);
            }
        }
    }
}
