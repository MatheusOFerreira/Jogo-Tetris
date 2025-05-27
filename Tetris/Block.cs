using System.Collections.Generic;

namespace Tetris
{
    public abstract class Block
    {
        protected abstract Position[][] Tiles { get; }
        protected abstract Position StartOffset { get; }
        public abstract int Id { get; }

        private int rotationState;
        private Position offset;

        public Block()
        {
            offset = new Position(StartOffset.Row, StartOffset.Column);
        }

        //Método que retorna as posições da grade ocupadas pelo bloco fatorando na rotação atual e deslocamento
        public IEnumerable<Position> TilePositions()
        {
            //O método vai fazer um loop sobre as posições dos bloco no estrado de rotação atual e adiciona o deslocamento da linha e o deslocamento da coluna
            foreach (Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        //Este método gira o bloco 90 graus no sentido horário, isso será incrementado oe estado de rotação atual, voltando para zero se estiver no estado final
        public void RotateCW()
        {
            rotationState = (rotationState + 1) % Tiles.Length;
        }

        //Gira no sentido anti-horário
        public void RotateCCW()
        {
            if (rotationState == 0)
            {
                rotationState = Tiles.Length - 1;
            }
            else
            {
                rotationState--;
            }

        }

        //Método que vai mover o bloco dependendo de um determinado numero de linhas e colunas
        public void Move(int rows, int columns)
        {
            offset.Row += rows;
            offset.Column += columns;
        }

        //Método que define a rotação e a posição
        public void Reset()
        {
            rotationState = 0;
            offset.Row = StartOffset.Row;
            offset.Column = StartOffset.Column;
        }

    }
}
