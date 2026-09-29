/*
 * This file was automatically generated.
 */
namespace OnlinePayments.Sdk.Domain
{
    public class ProblemDetailsResponse
    {
        /// <summary>
        /// A human-readable explanation specific to this occurrence of the problem.
        /// </summary>
        public string Detail { get; set; }

        /// <summary>
        /// A URI reference that identifies the specific occurrence of the problem.
        /// </summary>
        public string Instance { get; set; }

        /// <summary>
        /// The HTTP status code.
        /// </summary>
        public int? Status { get; set; }

        /// <summary>
        /// A short, human-readable summary of the problem type.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// A URI reference that identifies the problem type.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ProblemDetailsResponse WithDetail(string value)
        {
            Detail = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ProblemDetailsResponse WithInstance(string value)
        {
            Instance = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ProblemDetailsResponse WithStatus(int? value)
        {
            Status = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ProblemDetailsResponse WithTitle(string value)
        {
            Title = value;
            return this;
        }

        /// <summary>
        /// Sets the property and returns this same instance.
        /// </summary>
        public ProblemDetailsResponse WithType(string value)
        {
            Type = value;
            return this;
        }
    }
}
