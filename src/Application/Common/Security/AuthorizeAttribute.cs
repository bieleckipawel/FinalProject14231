using Microsoft.AspNetCore.Authorization;

namespace FinalProject14231.Application.Common.Security
{
    /// <summary>
    /// Specifies the class this attribute is applied to requires authorization.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeAttribute : Microsoft.AspNetCore.Authorization.AuthorizeAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeAttribute"/> class. 
        /// </summary>
        public AuthorizeAttribute() : base() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorizeAttribute"/> class. 
        /// </summary>
        public AuthorizeAttribute(string policy) : base(policy) { }

        /// <summary>
        /// Gets or sets a comma delimited list of roles that are allowed to access the resource.
        /// </summary>
        public new string Roles
        {
            get => base.Roles!;
            set => base.Roles = value;
        }

        /// <summary>
        /// Gets or sets the policy name that determines access to the resource.
        /// </summary>
        public new string Policy
        {
            get => base.Policy!;
            set => base.Policy = value;
        }
    }
}
