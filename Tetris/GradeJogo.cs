namespace Tetris
{
    public class GradeJogo
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int r, int c]
        {
            get { return grid[r, c]; }
            set { grid[r, c] = value; }

        }

        public GradeJogo(int linhas, int colunas)
        {
            Rows = linhas;
            Columns = colunas;
            grid = new int[linhas, colunas];
        }

        //Método que verifica se uma determinada linha e coluna está dentro da grade do jogo
        public bool IsInside(int r, int c)
        {
            //Linha deve ser maior ou igual a zero e menor que o número de linhas
            //Da mesma forma, a coluna deve ser menor que o número de colunas
            return r >= 0 && r < Rows && c >= 0 && c < Columns;
        }

        //Método para verificar se uma determinada célula está vazia ou não
        public bool IsEmpty(int r, int c)
        {
            //Precisa estar dentro da gfrade e o valor nessa entrada na matriz, deve ser zero. Isso significa que a célula ta vazia
            return IsInside(r, c) && grid[r, c] == 0;
        }

        //Método que verifica se uma linha inteira está cheia
        public bool IsRowFull(int r)
        {
            //Recebe como parametro a linha e vai pulando de coluna em coluna
            //Se a grade na posição da linha e a coluna que vai se incrementando for igual a zero, a linha não está cheia
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] == 0)
                {
                    return false;
                }
            }
            return true;
        }

        //Método parecido com o superior, este verifica se a linha está vazia
        public bool IsRowEmpty(int r)
        {
            for (int c = 0; c< Columns; c++)
            {
                if(grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }


    }
}
