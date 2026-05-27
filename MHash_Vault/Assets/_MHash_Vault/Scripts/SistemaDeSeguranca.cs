using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class SistemaDeSeguranca : MonoBehaviour
{
    [Header("Objetos do Cenário")]
    public GameObject sensorBiometrico;
    public Light luzDaSala; 

    [Header("Interface (UI)")]
    public TextMeshProUGUI textoPedestal;

    [Header("Configuração dos Tokens")]
    public GameObject token01; // Roxo
    public GameObject token02; // Amarelo
    public GameObject token03; // Laranja

    // Referências internas aos materiais
    private Material mat01, mat02, mat03;
    private Color corBase01, corBase02, corBase03;
    
    // MEMÓRIA DA LUZ DA SALA
    private Color corOriginalLuz;
    private float intensidadeOriginalLuz;

    // Lógica do Puzzle
    private List<GameObject> sequenciaCorreta;
    private int passoAtual = 0;
    private bool desafioAtivo = false;

    // Intensidade do efeito Neon (HDR)
    private float intensidadeNeon = 5.0f; 

    void Start()
    {
        // Salva a sua luz original
        if (luzDaSala != null)
        {
            corOriginalLuz = luzDaSala.color;
            intensidadeOriginalLuz = luzDaSala.intensity;
        }

        // Pega os materiais e ativa a emissão (Neon)
        mat01 = token01.GetComponent<Renderer>().material;
        mat01.EnableKeyword("_EMISSION");
        corBase01 = mat01.color; 

        mat02 = token02.GetComponent<Renderer>().material;
        mat02.EnableKeyword("_EMISSION");
        corBase02 = mat02.color;

        mat03 = token03.GetComponent<Renderer>().material;
        mat03.EnableKeyword("_EMISSION");
        corBase03 = mat03.color;

        // Desliga o neon no começo
        DesligarNeon(mat01);
        DesligarNeon(mat02);
        DesligarNeon(mat03);

        // Define a cor do texto como PRETO definitivamente
        if (textoPedestal != null) 
        {
            textoPedestal.color = Color.black; 
            textoPedestal.text = "SISTEMA BLOQUEADO.\nMire e toque na Biometria.";
        }
    }

    void Update()
    {
        // MIRA FPS (Centro da tela)
        if (Input.GetMouseButtonDown(0))
        {
            Camera cam = Camera.main;
            if (cam == null) return;

            Vector3 centroDaTela = new Vector3(Screen.width / 2f, Screen.height / 2f, 0f);
            Ray raio = cam.ScreenPointToRay(centroDaTela);
            RaycastHit impacto;

            if (Physics.Raycast(raio, out impacto, 10f))
            {
                GameObject objetoClicado = impacto.transform.gameObject;

                if (objetoClicado == sensorBiometrico && !desafioAtivo)
                {
                    IniciarDesafio();
                }
                else if (desafioAtivo && (objetoClicado == token01 || objetoClicado == token02 || objetoClicado == token03))
                {
                    ProcessarCliqueToken(objetoClicado);
                }
            }
        }
    }

    void IniciarDesafio()
    {
        desafioAtivo = true;
        passoAtual = 0;
        
        DesligarNeon(mat01);
        DesligarNeon(mat02);
        DesligarNeon(mat03);
        
        if (luzDaSala != null) 
        {
            luzDaSala.color = corOriginalLuz;
            luzDaSala.intensity = intensidadeOriginalLuz;
        }

        // --- SISTEMA DE EMBARALHAMENTO (RANDOM) ---
        List<int> indices = new List<int> { 0, 1, 2 };

        // Sorteia os índices
        for (int i = 0; i < indices.Count; i++)
        {
            int temp = indices[i];
            int randomIndex = Random.Range(i, indices.Count);
            indices[i] = indices[randomIndex];
            indices[randomIndex] = temp;
        }

        // Cria a referência dos objetos e dos textos
        GameObject[] tokensArray = { token01, token02, token03 };
        string[] nomesArray = { "<color=#A200FF>●</color>", "<color=#FFE600>●</color>", "<color=#FF6600>●</color>" };

        sequenciaCorreta = new List<GameObject>();
        List<string> nomesSorteados = new List<string>();

        // Monta a nova ordem sorteada
        foreach (int index in indices)
        {
            sequenciaCorreta.Add(tokensArray[index]);
            nomesSorteados.Add(nomesArray[index]);
        }

        // Atualiza o texto holográfico
        if (textoPedestal != null)
        {
            textoPedestal.text = "SENHA GERADA:\n" + nomesSorteados[0] + " -> " + nomesSorteados[1] + " -> " + nomesSorteados[2];
        }
    }

    void ProcessarCliqueToken(GameObject tokenClicado)
    {
        if (tokenClicado == sequenciaCorreta[passoAtual])
        {
            passoAtual++;
            
            // Acende a cor original do Token
            if (tokenClicado == token01) AtivarNeon(mat01, corBase01);
            if (tokenClicado == token02) AtivarNeon(mat02, corBase02);
            if (tokenClicado == token03) AtivarNeon(mat03, corBase03);

            if (passoAtual >= sequenciaCorreta.Count)
            {
                FinalizarPuzzle(true); 
            }
        }
        else
        {
            FinalizarPuzzle(false); 
        }
    }

    void FinalizarPuzzle(bool sucesso)
    {
        desafioAtivo = false;

        if (sucesso)
        {
            MudarTudoParaCorNeon(Color.green);
            if (textoPedestal != null)
            {
                textoPedestal.text = "ACESSO LIBERADO.\nTokens MHash Validados.";
            }
        }
        else
        {
            MudarTudoParaCorNeon(Color.red);
            if (textoPedestal != null)
            {
                textoPedestal.text = "ERRO DE SEGURANÇA.\nBloqueio de Sistema Ativado.";
            }
        }
    }

    void AtivarNeon(Material mat, Color corBase)
    {
        Color corNeon = corBase * intensidadeNeon;
        mat.SetColor("_EmissionColor", corNeon);
    }

    void DesligarNeon(Material mat)
    {
        mat.SetColor("_EmissionColor", Color.black);
    }

    void MudarTudoParaCorNeon(Color corFinal)
    {
        if (luzDaSala != null)
        {
            luzDaSala.color = corFinal;
            luzDaSala.intensity = intensidadeOriginalLuz * 2f; 
        }

        Color corFinalHDR = corFinal * intensidadeNeon;
        mat01.SetColor("_EmissionColor", corFinalHDR);
        mat02.SetColor("_EmissionColor", corFinalHDR);
        mat03.SetColor("_EmissionColor", corFinalHDR);
    }
}