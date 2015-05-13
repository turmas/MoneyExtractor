using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyExtractor.Core.Processors {
    public static class ProcessorFactory {

        /// <summary>
        /// Fábrica de processador de troco
        /// </summary>
        /// <param name="changeAmount">Troco</param>
        /// <returns>Processador</returns>
        public static AbstractProcessor Create(long changeAmount) {
            //Lista de processadores
            IEnumerable<AbstractProcessor> processorList = new AbstractProcessor[]{
                new BillProcessor(), 
                new CoinProcessor(),
                new SilverProcessor(),
                new CandyProcessor(),

                //Adicionar novos processador acima desta linha
            };

            //Percorrer a lista
            foreach (AbstractProcessor processorItem in processorList.OrderByDescending(o => o.MoneyTypeList.Min())) {
                //Dentro da lista acessar o item e verificar se o menor valor é maior que o troco
                if (changeAmount >= processorItem.MoneyTypeList.Min()) {
                    //Retorno
                    return processorItem;
                }
            }

            //Retorno
            return null;
        }
    }
}
