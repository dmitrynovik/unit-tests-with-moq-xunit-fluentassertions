using Moq;

class Mocked
{

    Mock<ICustomerService> mock;

    void Setup()
    {
        // any value
        mock.Setup(service => service.GetCustomers(It.IsAny<string>())).Returns(new[] { new Customer("Donald Trump") });

        // matching Func<string>, lazy evaluated
        mock.Setup(service => service.GetCustomers(It.Is<string>(s => s == null))).Returns(new[] { new Customer("UNKNOWN") }); 

        // matching ranges
        //mock.Setup(foo => foo.Add(It.IsInRange<int>(0, 10, Range.Inclusive))).Returns(true);
    }

    void Verify()
    {
        //mock.Verify(foo => foo.DoSomething("ping"));

        //// Verify with custom error message for failure
        //mock.Verify(foo => foo.DoSomething("ping"), "When doing operation X, the service should be pinged always");

        //// Method should never be called
        //mock.Verify(foo => foo.ReportError(It.IsAny<Exception>, Times.Never());

        //// Called at least once
        //mock.Verify(foo => foo.Save(), Times.AtLeastOnce());

        //// Verify getter invocation, regardless of value.
        //mock.VerifyGet(foo => foo.Name);

        //// Verify setter invocation, regardless of value.
        //mock.VerifySet(foo => foo.Name);

        //// Verify setter called with specific value
        //mock.VerifySet(foo => foo.Name ="foo");

        //// Verify setter with an argument matcher
        //mock.VerifySet(foo => foo.Value = It.IsInRange(1, 5, Range.Inclusive));

        //// Verify that no other invocations were made other than those already verified (requires Moq 4.8 or later)
       //mock.VerifyNoOtherCalls();
    }
}