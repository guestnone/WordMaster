
namespace WordMaster.Core
{
    /// <summary>
    /// Profficiency levels
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
    /// Structure used to store user's information
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