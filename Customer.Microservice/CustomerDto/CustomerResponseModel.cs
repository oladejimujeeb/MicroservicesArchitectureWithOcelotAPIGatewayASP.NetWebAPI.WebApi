namespace Customer.Microservice.CustomerDto
{
    public class CustomerResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }

        public CustomersDto Data { get; set; }
    }

    public class CustomersResponseModel
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public IEnumerable<CustomersDto> Data { get; set; }   
    }
}
