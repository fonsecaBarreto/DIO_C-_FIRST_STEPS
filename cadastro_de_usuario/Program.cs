using System;

namespace cadastro_de_usuario
{
    class Program
    {
        static void Main(string[] args)
        {
            string clientInput;
            Aluno[] alunos = new Aluno[5];
            int alunos_indice = 0;

            Console.WriteLine("\n :: Bem Vindo ao Gerenciador de Usuario! ::");
            clientInput = getClientInput();

            while(clientInput.ToUpper() != "X"){
                HandleClientInput(clientInput, alunos,  ref alunos_indice);
                clientInput = getClientInput();
            }
            
        }

        static void HandleClientInput(string input, Aluno[] list, ref int indice ){
            Console.WriteLine();
            switch (input)
            {
                case "1": AddAluno(list, ref indice); break;
                case "2": ListAlunos(list); break;
                case "3": CalcMedia(list); break;
                default: throw new ArgumentOutOfRangeException("Opção nao existe!");
            }
            Console.WriteLine("\n------------------------------------------");
        }

        static string getClientInput(){
            Console.WriteLine("\n> Indique Qual a operação desejada? ");
            Console.WriteLine(" > (1) - Cadastrar um novo usuario.");
            Console.WriteLine(" > (2) - Listar usuarios.");
            Console.WriteLine(" > (3) - Calcular a media geral.");
            Console.WriteLine(" > (X) - Sair ");
            Console.Write(" : ");
            return Console.ReadLine();
        }

        static void AddAluno(Aluno[] list, ref int indice){
            Aluno aluno = new Aluno();
            decimal grade;

            Console.Write(" Informe o nome do Aluno: ");
            aluno.name = Console.ReadLine();

            Console.Write($" Informe a nota do Aluno {aluno.name}: ");

            if (decimal.TryParse(Console.ReadLine(), out grade)) {
                aluno.grade = grade;
            } else {
                throw new ArgumentOutOfRangeException("Informe um nota com valor decimal correto para prosseguir!"); // Trocar por uma execção mais adequada
            }
            
            list[indice]=aluno;
            indice++;

            Console.WriteLine(" [ Novo Aluno Adicionado com sucesso! ]");
        }


        static void ListAlunos(Aluno[] list){
            Console.WriteLine("\n Listagem de Alunos: \n");
            int indice = 0;
            foreach (Aluno aluno in list) {
                if (!string.IsNullOrEmpty(aluno.name)) {
                    indice++;
                    Console.WriteLine($" {indice} - Aluno: {aluno.name}, nota: {aluno.grade}");
                }
            }
        }

        static void CalcMedia(Aluno[] list){
            int alunosTotal = 0 ;
            decimal totalGrades = 0 ;
            decimal mediaGeral;
            Conceito conceito;

            for(int i = 0 ;  i < list.Length; i ++){
                if(!string.IsNullOrEmpty(list[i].name)){
                    totalGrades = totalGrades + list[i].grade ;
                    alunosTotal++;
                }
            }
            mediaGeral = totalGrades / alunosTotal;

            if(mediaGeral > 3){
                if (mediaGeral >= 8){
                    conceito = Conceito.A;
                }
                else if (mediaGeral >= 7){
                    conceito = Conceito.B;
                }
                else if (mediaGeral >= 6){
                    conceito = Conceito.C;
                }
                else if (mediaGeral >= 5){
                    conceito = Conceito.D;
                }else{
                    conceito = Conceito.E;
                }
            }else{
                conceito = Conceito.F;
            }

            Console.WriteLine($"Media Geral: {mediaGeral}, Conceito: {conceito}");

        }

    }
}
