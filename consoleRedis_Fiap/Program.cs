using StackExchange.Redis;


//TESTE PAAR FUNCIONAR LOCALMENTE


for (int perguntas = 1; perguntas <= 10; perguntas ++)
{
    //MENSAGEM COLETADA DO CONSOLE
    var valorVariavel = perguntas * 3 + 10;
    var x = "P"+ perguntas + ":Qual o resultado de 200-"+ valorVariavel + "?";
    //IDENTIFICANDO O ID
    var id = x.Split(':')[0];
    //IDENTIFICANDO A PERGUNTA
    var pergunta = x.Split(':')[1];

    var valor1 = "";
    var valor2 = "";
    bool primeiroValorColetado = false;
    bool operadorColetado = false;
    bool segundoValorColetado = false;
    char? operador = null;
    //RECUPERANDO OS VALORES E O TIPO DE OPERAÇÃO

    for (int i = 0; i < pergunta.ToString().Length; i++)
    {
        //RECUPERA O PRIMEIRO VALOR
        if (Char.IsDigit(pergunta.ToString()[i]) && operadorColetado == false)
        {
            valor1 += pergunta.ToString()[i];
            primeiroValorColetado = true;
        }

        //RECUPERA O OPERADOR DA OPERAÇÃO
        else if (!Char.IsDigit(pergunta.ToString()[i]) && primeiroValorColetado == true && !pergunta[i].ToString().Equals("?"))
        {
            operador = pergunta[i];
            operadorColetado = true;
        }

        //RECUPERA O SEGUNDO VALOR
        else if (Char.IsDigit(pergunta.ToString()[i]) && operadorColetado == true && primeiroValorColetado == true)
        {
            valor2 += pergunta.ToString()[i];
            segundoValorColetado = true;
        }

        //SE TODOS OS VALORES FORAM RECUPERADOS COM SUCESSO, REALIZA O CALCULO DA OPERAÇÃO
        else if (primeiroValorColetado && segundoValorColetado && operadorColetado)
        {

            var resultado = 0;
            if (operador.Equals('+'))
                resultado = int.Parse(valor1) + int.Parse(valor2);
            else if (operador.Equals('-'))
                resultado = int.Parse(valor1) - int.Parse(valor2);
            else if (operador.Equals('x') || operador.Equals('*'))
                resultado = int.Parse(valor1) * int.Parse(valor2);
            else if (operador.Equals('/'))
                resultado = int.Parse(valor1) / int.Parse(valor2);

            Console.WriteLine("Pergunta: " + id + " | " + pergunta + " | " + "O resultado é: " + resultado);
            //dbCont.HashSet(id, "DevsIOBot", "O resultado da operação é: " + resultado);
        }
    }
}





/////////////////////////////////////////////////////////////////////// EXERCICIO //////////////////////////////////////////////////////////
///////////////////////////////////////////////////////////////////////// DESCOMENTAR CODIGO ABAIXO PARA TESTAR PELO SERVIDOR //////////////////////////////////////////////////////////

//string connectionString = "20.225.241.127";
//var redis = ConnectionMultiplexer.Connect(connectionString);
//var dbCont = redis.GetDatabase();
//var sub = redis.GetSubscriber();
////var pub = redis.GetSubscriber();


//sub.Subscribe("perguntas").OnMessage(
//    mbox =>
//    {
//        var resultado = 0;
//        Console.WriteLine(mbox.Message);

//        var id = mbox.Message.ToString().Split(':')[0];
//        //IDENTIFICANDO A PERGUNTA
//        var pergunta = mbox.Message.ToString().Split(':')[1];

//        var valor1 = "";
//        var valor2 = "";
//        bool primeiroValorColetado = false;
//        bool operadorColetado = false;
//        bool segundoValorColetado = false;
//        char? operador = null;

//        //RECUPERANDO OS VALORES E O TIPO DE OPERAÇÃO

//        for (int i = 0; i < pergunta.ToString().Length; i++)
//        {
//            //RECUPERA O PRIMEIRO VALOR
//            if (Char.IsDigit(pergunta.ToString()[i]) && operadorColetado == false)
//            {
//                valor1 += pergunta.ToString()[i];
//                primeiroValorColetado = true;
//            }

//            //RECUPERA O OPERADOR DA OPERAÇÃO
//            else if (!Char.IsDigit(pergunta.ToString()[i]) && primeiroValorColetado == true && !pergunta[i].ToString().Equals("?"))
//            {
//                operador = pergunta[i];
//                operadorColetado = true;
//            }

//            //RECUPERA O SEGUNDO VALOR
//            else if (Char.IsDigit(pergunta.ToString()[i]) && operadorColetado == true && primeiroValorColetado == true)
//            {
//                valor2 += pergunta.ToString()[i];
//                segundoValorColetado = true;
//            }

//            //SE TODOS OS VALORES FORAM RECUPERADOS COM SUCESSO, REALIZA O CALCULO DA OPERAÇÃO
//            else if (primeiroValorColetado && segundoValorColetado && operadorColetado)
//            {


//                if (operador.Equals('+'))
//                    resultado = int.Parse(valor1) + int.Parse(valor2);
//                else if (operador.Equals('-'))
//                    resultado = int.Parse(valor1) - int.Parse(valor2);
//                else if (operador.Equals('x') || operador.Equals('*'))
//                    resultado = int.Parse(valor1) * int.Parse(valor2);
//                else if (operador.Equals('/'))
//                    resultado = int.Parse(valor1) / int.Parse(valor2);

//                Console.WriteLine(resultado);
//            }
//        }
//        var x = mbox.Message;


//        dbCont.HashSet(id, "DevsIOBot", "O resultado da operação é: " + resultado);

//    });


//Console.ReadLine();
