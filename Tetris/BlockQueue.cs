using System;
namespace Tetris
{
    //Classe responsável por dizer quem é a próxima peça no jogo
    //Contém uma matriz de blocos com uma instrancia das 7 classes de blocos 
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        //Objeto aleatório 
        private readonly Random random = new Random();

        public Block NextBlock { get; private set; }

        public BlockQueue()
        {
            NextBlock = RandomBlock();
        }

        //Método que retorna um bloco aleatório
        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        //Método que retorna o próximo bloco e atualiza a propriedade
        public Block GetAndUpdate()
        {
            Block block = NextBlock;

            do
            {
                NextBlock = RandomBlock();
            } while (block.Id == NextBlock.Id); //Para não retornar o mesmo bloco duas vezes seguidas

            return block;
        }
    }
}
