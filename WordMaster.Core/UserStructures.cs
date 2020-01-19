
namespace WordMaster.Core
{

    public enum ProficiencyType
    {
        Basic,
        UnderIntermediate,
        Intermediate,
        UpperIntermediate,
        Advanced
    }

    public class UserState
    {
        public string mFirstName;
        public string mLastName;
        public ProficiencyType mProficiencyType;
        public int mWrongAnswerCount;
        public int mGoodAnswerCount;
    }

}