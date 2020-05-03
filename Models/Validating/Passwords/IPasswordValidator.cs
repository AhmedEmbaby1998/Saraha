using SimpleSaraha.Models.Entities;

namespace Embaby.Models.Validating
{
    public interface IPasswordValidator
    {
        bool IsValid();
        void Validate(User user);
    }
}