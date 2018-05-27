namespace Controller
{
    using System;

    public class Soldier : IComparable<Soldier>
    {
        public const char k_FirstPlayerKing = 'U';
        public const char k_SecondPlayerKing = 'K';
        public const char k_FirstPlayerRegular = 'O';
        public const char k_SecondPlayerRegular = 'X';
        public const char k_EmptySolider = ' ';
        private char m_CharRepresent;
        private eSoldierType m_TypeOfSoldier;
        private Square m_PlaceOnBoard;
		public event Action<Square, Square> StartAnimationOfSoliderMovingAfterChangePlaceOnBoard;
		public event Action<Soldier> ChangePictureOfSoliderAfterChangedType;
		public event Action<Soldier> RemoveSoliderFromBoard;

        public Soldier(char i_CharRepresent, Square i_PlaceOnBoard, eSoldierType i_TypeOfSolider = eSoldierType.Regular)
        {
            m_TypeOfSoldier = i_TypeOfSolider;
			m_PlaceOnBoard = i_PlaceOnBoard;
            CharRepresent = i_CharRepresent;
        }

        public Soldier(Soldier i_CurrentSolider)
        {
            m_CharRepresent = i_CurrentSolider.m_CharRepresent;
            m_PlaceOnBoard = i_CurrentSolider.m_PlaceOnBoard;
            m_TypeOfSoldier = i_CurrentSolider.m_TypeOfSoldier;
        }

        public char CharRepresent
        {
            get
            {
                return m_CharRepresent;
            }

            set
            {
                m_CharRepresent = value;
            }
        }

        public eSoldierType TypeOfSoldier
        {
            get
            {
                return m_TypeOfSoldier;
            }

            set
            {
				m_TypeOfSoldier = value;
				OnChangePictureOfSoliderAfterChangedType(value);            
            }
        }

        public Square PlaceOnBoard
        {      
            get
            {
                return m_PlaceOnBoard;
            }

            set
            {

				OnStartAnimationOfSoliderMovingAfterChangePlaceOnBoard(value);
            }
        }

		public void InvokeRemoveSoliderFromboard()
        {
			OnRemoveSoliderFromBoard();
        }

		protected virtual void OnStartAnimationOfSoliderMovingAfterChangePlaceOnBoard(Square i_SquareToChange)
        {
			Square oldSquare = m_PlaceOnBoard;
			Square newSquare = i_SquareToChange;
            m_PlaceOnBoard = i_SquareToChange;
            if (StartAnimationOfSoliderMovingAfterChangePlaceOnBoard != null)
            {
				StartAnimationOfSoliderMovingAfterChangePlaceOnBoard.Invoke(oldSquare, newSquare);     
            }
        }

		protected virtual void OnChangePictureOfSoliderAfterChangedType(eSoldierType i_TypeOfSolider)
        {
			if (ChangePictureOfSoliderAfterChangedType != null)
            {
				ChangePictureOfSoliderAfterChangedType.Invoke(this);
            }
        }

		protected virtual void OnRemoveSoliderFromBoard()
        {
			if (RemoveSoliderFromBoard != null)
            {
				RemoveSoliderFromBoard.Invoke(this);
            }
        }

        public int CompareTo(Soldier i_Other)
        {
            return this.m_PlaceOnBoard.Col.CompareTo(i_Other.m_PlaceOnBoard.Col);
        }
    }
}
