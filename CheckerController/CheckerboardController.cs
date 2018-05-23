namespace Controller
{
    public class CheckerboardController
    {
		private static CheckerBoard m_Instance = null;
		
		public static CheckerBoard Instance
        {
			get
			{
				if (m_Instance == null)
				{
					m_Instance = new CheckerBoard();
				}
				return m_Instance;
			}
        }
    }
}
