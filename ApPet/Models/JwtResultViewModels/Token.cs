using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApPet.Models
{
    public class Token : JwtResult
    {
        public string token { get; set; }
        public int expires { get; set; }
    }

    public class JwtErrors : JwtResult
    {
        private List<JwtError> _errors;

        public IReadOnlyCollection<JwtError> errors { get => _errors.AsReadOnly(); }

        public JwtErrors()
        {
            _errors = new List<JwtError>();
        }

        public void Add(JwtError error)
        {
            if (ok)
                ok = false;

            _errors.Add(error);
        }

        public static JwtError CreateError(JwtErrorTypes errorType, Object error = null) 
        {
            switch (errorType)
            {
                case JwtErrorTypes.IsLockedOut:
                    return new JwtError("JE01", "IsLockedOut", "the user attempting to sign-in is locked out");
                case JwtErrorTypes.IsNotAllowed:
                    return new JwtError("JE02", "IsNotAllowed", "the user attempting to sign-in is not allowed to sign-in");
                case JwtErrorTypes.RequiresTwoFactor:
                    return new JwtError("JE03", "RequiresTwoFactor", "the user attempting to sign-in requires two factor authentication");
                case JwtErrorTypes.InvalidUsernamePassword:
                    return new JwtError("JE04", "InvalidUsernamePassword", "the user attempting to sign-in doesn't match password or user");
                case JwtErrorTypes.DuplicateUserName:
                    return new JwtError("JE05", "DuplicateUserName", ((IdentityError)error).Code);
                case JwtErrorTypes.ErrorInConfirmPassword:
                    return new JwtError("JE06", "ConfirmPassword", ((ModelError)error).ErrorMessage);
                case JwtErrorTypes.ErrorInEmail:
                    return new JwtError("JE07", "RequiredEmail", ((ModelError)error).ErrorMessage);
                case JwtErrorTypes.ErrorInPassword:
                    return new JwtError("JE08", "RequiredPassword", ((ModelError)error).ErrorMessage);
                default: return null;  
            }
        }        
    }
    
    public class JwtError
    {
        public JwtError(string code, string name, string description)
        {
            this.code = code;
            this.name = name;
            this.description = description;
        }

        public string description { get; }
        public string name { get; }
        public string code { get; }
    }

    public enum JwtErrorTypes { IsLockedOut, IsNotAllowed, RequiresTwoFactor, InvalidUsernamePassword, DuplicateUserName, ErrorInConfirmPassword, ErrorInEmail, ErrorInPassword }

    public class JwtResult
    {
        public bool ok { get; set; } = true;
    }
}
