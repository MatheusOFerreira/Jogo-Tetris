namespace Tetris
{
    public class GameGrid
    {
        private readonly int[,] grid;
        public int Rows { get; }
        public int Columns { get; }

        public int this[int r, int c]
        {
            get { return grid[r, c]; }
            set { grid[r, c] = value; }

        }

        public GameGrid(int linhas, int colunas)
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
            for (int c = 0; c < Columns; c++)
            {
                if (grid[r, c] != 0)
                {
                    return false;
                }
            }
            return true;
        }

        //Método que limpa a linha quando ela está completa
        private void ClearRow(int r)
        {
            for (int c = 0; c < Columns; c++)
            {
                grid[r, c] = 0;
            }
        }

        //Método que move a linha para baixo
        //Recebe o r(linha que será mexida) e a quantidade de linhas que a linha R será movida para baixo
        private void MoveRowDown(int r, int numRows)
        {
            for (int c = 0; c < Columns; c++)
            {
                //Move a célula atual para a posição r + linhas abaixo
                grid[r + numRows, c] = grid[r, c];
                //Move e apaga, pra mostrar que tá vazia
                grid[r, c] = 0;
            }
        }

        public int ClearFullRows()
        {
            //A variável limpa vai começar em 0 e será movida da linha inferior para a superior
            int cleared = 0;

            for (int r = Rows - 1; r >= 0; r--)
            {
                //Vamos verificar se a linha atual está cheia e se estiver, irá ser limpada e incrementada
                if (IsRowFull(r))
                {
                    ClearRow(r);
                    cleared++;
                }
                //Caso contrário, se limpo for maior que zero, vamos mover a linha atual para baixo pelo número de linhas limpas
                else if (cleared > 0)
                {
                    MoveRowDown(r, cleared);
                }
            }
            return cleared;
        }
    }
}
