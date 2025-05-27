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
            foreach(Position p in Tiles[rotationState])
            {
                yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
            }
        }

        //Este método gira o bloco 90 graus no sentido horário, isso será incrementado oe stado de rotação atual voltando para zero se estiver no estado final

    }
}
