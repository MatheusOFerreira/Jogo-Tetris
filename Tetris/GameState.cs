namespace Tetris
{
    //Classe que manipula as interações entre as partes
    public class GameState
    {
        private Block currentBlock;

        public Block CurrentBlock
        {
            get => currentBlock;
            private set
            {
                //Quando atualizamos obloco atual, o metodo de reiniciar é chamado para redefinir a posição inicial e a rotação correta
                currentBlock = value;
                currentBlock.Reset();
            }
        }

        public GameGrid GameGrid { get; }
        public BlockQueue BlockQueue { get; }
        public bool GameOver { get; private set; }


        //No construtor, vamos iniciar a grade do jogo com 22 linhas e 10 colunas. Além dsso, vamos inicializar a fila de blocos e vamos usar para obeter um bloco aleat´roio para a propriedade do bloco atual
        public GameState()
        {
            GameGrid = new GameGrid(22, 10);
            BlockQueue = new BlockQueue();
            CurrentBlock = BlockQueue.GetAndUpdate();
        }

        //Método que verifica se o bloco atual está em uma posição válida ou não
        private bool BlockFits()
        {
            foreach (Position P in CurrentBlock.TilePositions())
            {
                if (!GameGrid.IsEmpty(P.Row, P.Column))
                {
                    return false;
                }
            }

            return true;
            //O método faz um loop nas posições dos blocos atuais e, se algum deles tiver fora da grade ou sobrepondo outro bloco, vai retornar falso.
            //Caso contrário, se passarmos por todo o loop, retornará verdadeiro
        }

        //Método para girar o bloco atual no sentido horário, mas somente se for possível fazer isso de onde ele está
        public void RotateBlockCW()
        {
            CurrentBlock.RotateCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCCW();
                //Vamos girar o bloco e, se ele acabar em uma posição ilegal, o giramos de volta. 
            }
        }

        //Método para girar o bloco atual no sentido anti-horário, mas somente se for possível fazer isso de onde ele está
        public void RotateBlockCCW()
        {
            CurrentBlock.RotateCCW();
            if (!BlockFits())
            {
                CurrentBlock.RotateCW();
                //Vamos girar o bloco e, se ele acabar em uma posição ilegal, o giramos de volta. 
            }
        }

        public void MoveBlockLeft()
        {
            CurrentBlock.Move(0, -1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, 1);
            }
        }

        public void MoveBlockRight()
        {
            CurrentBlock.Move(0, 1);
            if (!BlockFits())
            {
                CurrentBlock.Move(0, -1);
            }
        }

        private bool IsGameOver()
        {
            //Se alguma das linhas ocultas no topo não estiver vazia, o jogo será perdido
            return !(GameGrid.IsRowEmpty(0) && GameGrid.IsRowEmpty(1));
        }

        //Este método vai ser chamado quado o bloco atual não puder ser movido para baixo
        private void PlaceBlock()
        {
            //Primeiro ele faz um loop nas posições dos blocos atuais e define essas posicoes na grade do jogo iguais ao id do bloco
            foreach(Position p in CurrentBlock.TilePositions())
            {
                GameGrid[p.Row, p.Column] = CurrentBlock.Id;
            }

            //Então limpamos toda as linhas potencialmente cheias
            GameGrid.ClearFullRows();

            //Verfica se o jogo acabou
            if (IsGameOver())
            {
                GameOver = true;
            }
            else
            {
                CurrentBlock = BlockQueue.GetAndUpdate();
            }
        }

        public void MoveBlockDown()
        {
            CurrentBlock.Move(1, 0);

            if (!BlockFits())
            {
                CurrentBlock.Move(-1, 0);
                PlaceBlock();

                //Funciona como os outros, menos que chamamos o metodo placeblock caso o bloco não possa seer movido para baixo nesse ponto
            }
        }

    }
}
