
namespace WordMaster.Core
{

    /// <summary>
    /// Type of a proficiency of a user.
    /// </summary>
    public enum ProficiencyType
    {
        Basic,
        UnderIntermediate,
        Intermediate,
        UpperIntermediate,
        Advanced
    }

    /// <summary>
    /// Contains the state of a user.
    /// </summary>
    public class UserState
    {
        public string mFirstName;
        public string mLastName;
        public ProficiencyType mProficiencyType;
        public int mWrongAnswerCount;
        public int mGoodAnswerCount;
    }

}