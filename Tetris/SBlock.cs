namespace Tetris
{
    public class SBlock : Block
    {
        //Classe que representa a peça I do jogo, tiles contém todas rotações possíveis
        private readonly Position[][] tiles = new Position[][]
        {
            new Position[] { new Position(0,1), new Position(0,2), new Position(1,0), new Position(1,1) },
            new Position[] { new Position(0,1), new Position(1,1), new Position(1,2), new Position(2,2) },
            new Position[] { new Position(1,1), new Position(1,2), new Position(2,0), new Position(2,1) },
            new Position[] { new Position(0,0), new Position(1,0), new Position(1,1), new Position(2,1) }
        };

        //Id UNICO para a peça I
        public override int Id => 5;
        //Definição da posição inicial da peça no jogo
        protected override Position StartOffset => new Position(0, 3);
        protected override Position[][] Tiles => tiles;
    }
}
