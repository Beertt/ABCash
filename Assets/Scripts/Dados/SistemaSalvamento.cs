using UnityEngine;
using System.IO;

public static class SistemaSalvamento {
    public static void SalvarDado(int questao, string resposta) {
        string caminhoSalvar = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/respostas.json";

        DadoQuestao dadoQuestao = new DadoQuestao(questao, resposta);

        string dadoJson = "";
        if (CarregarDado() != null) {
            dadoJson = CarregarDado() + "\n";
        }
        dadoJson += JsonUtility.ToJson(dadoQuestao, true);
        File.WriteAllText(caminhoSalvar,dadoJson);

        CarregarDado();
    }

    public static string CarregarDado() {
        string caminhoCarregar = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Desktop) + "/respostas.json";
        if (File.Exists(caminhoCarregar)) {
            string dado = File.ReadAllText(caminhoCarregar);
            return dado;
        }
        return null;
    }
}
