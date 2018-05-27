namespace View
{
	using System;
	using Controller;

	public class TagSolider : TagName
    {
        private eNumberOfPlayer m_NumberOfPlayer;

        public TagSolider(String i_SetName, eNumberOfPlayer i_NumberOfPlayer) : base(i_SetName)
        {
            m_NumberOfPlayer = i_NumberOfPlayer;
        }

        public eNumberOfPlayer NumberOfPlayer
        {
            get
            {
                return m_NumberOfPlayer;
            }
        }
    }
}
