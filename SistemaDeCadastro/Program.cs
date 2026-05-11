using System;
using System.Collections.Generic;
using System.IO;

string arquivo = "contatos.txt";

List<string> contatos = new List<string>();


if (File.Exists(arquivo))
{
    contatos.AddRange(File.ReadAllLines(arquivo));
}

while (true)
{
    Console.WriteLine("\n=== SISTEMA DE CADASTRO ===");
    Console.WriteLine("1. Adicionar contato");
    Console.WriteLine("2. Listar contatos");
    Console.WriteLine("3. Remover contato");
    Console.WriteLine("4. Sair");
    Console.Write("\nEscolha uma opção: ");

    string opcao = Console.ReadLine();

    if (opcao == "1")
    {
        Console.Write("Nome: ");
        string nome = Console.ReadLine();

        Console.Write("Telefone: ");
        string telefone = Console.ReadLine();

        Console.Write("Email: ");
        string email = Console.ReadLine();

        string contato = $"{nome} | {telefone} | {email}";
        contatos.Add(contato);
        File.WriteAllLines(arquivo, contatos);

        Console.WriteLine("✅ Contato cadastrado!");
    }
    else if (opcao == "2")
    {
        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato cadastrado.");
        }
        else
        {
            Console.WriteLine("\n--- CONTATOS ---");
            for (int i = 0; i < contatos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contatos[i]}");
            }
        }
    }
    else if (opcao == "3")
    {
        if (contatos.Count == 0)
        {
            Console.WriteLine("Nenhum contato para remover.");
        }
        else
        {
            Console.WriteLine("\n--- CONTATOS ---");
            for (int i = 0; i < contatos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {contatos[i]}");
            }

            Console.Write("Número do contato a remover: ");
            int numero = int.Parse(Console.ReadLine()) - 1;

            if (numero >= 0 && numero < contatos.Count)
            {
                contatos.RemoveAt(numero);
                File.WriteAllLines(arquivo, contatos);
                Console.WriteLine("✅ Contato removido!");
            }
            else
            {
                Console.WriteLine("Número inválido!");
            }
        }
    }
    else if (opcao == "4")
    {
        Console.WriteLine("Encerrando...");
        break;
    }
    else
    {
        Console.WriteLine("Opção inválida!");
    }
}