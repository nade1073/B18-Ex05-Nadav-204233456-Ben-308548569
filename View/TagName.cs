namespace View
{
	using System;

	public class TagName
    {
        private String m_String;

        public TagName(String i_SetName)
        {
			Name = i_SetName;
        }

        public String Name
        {
            get
            {
                return m_String;
            }

            set
            {
                m_String = value;
            }
        }
    }
}
