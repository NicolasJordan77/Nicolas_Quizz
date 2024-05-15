using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizzManager : MonoBehaviour
{
    [Header("Variaveis de Painel")]
    public GameObject painelInicio;
    public GameObject painelJogo;

    [Header("Objetos do Jogo")]
    public TMP_Text textoTitulo;
    public Image imagemQuizz;
    public TMP_Text textoPergunta;
    public TMP_Text[] textoResposta;

    [Header("Objeto de Musica")]
    public AudioSource caixaDeMusica;
    public AudioSource caixaDeEfeitos;

    [Header("Arquivos de Musica")]
    public AudioClip musicaMenu;
    public AudioClip musicaJogo;

    [Header("Arquivos de Efeito Sonoros")]
    public AudioClip efeitoAcerto;
    public AudioClip efeitoErrado;

    [Header("Conteúdo das Perguntas")]
    public string[] titulos;
    public Sprite[] imagens;
    public string[] perguntas;
    public string[] alternativa1;
    public string[] alternativa2;
    public string[] alternativa3;
    public string[] alternativa4;
    public int[] alternativaCorreta;
    public int perguntaAtual;
    private object alternatuva1;

    // Start is called before the first frame update
    void Start()
    {
        painelInicio.SetActive(true);
        painelJogo.SetActive(false);
        caixaDeMusica.clip = musicaMenu;
        caixaDeMusica.Play();
    }

    //Método para iniciar o jogo
    public void IniciarJogo()


    {
        painelInicio.SetActive(false);
        painelJogo.SetActive(true);
        ProximaPergunta(perguntaAtual);


    }

    //Métdo para fazer as perguntas
    public void ProximaPergunta(int numero)
    {
        textoTitulo.text = titulos[numero];
        imagemQuizz.sprite = imagens[numero];
        textoPergunta.text = perguntas[numero];
        textoResposta[0].text = alternativa1[numero];
        textoResposta[1].text = alternativa2[numero];
        textoResposta[2].text = alternativa3[numero];
        textoResposta[3].text = alternativa4[numero];
        textoResposta[3].text = alternativa4[numero];


    }

    //Método para chegar as perguntas
    public void ChecarResposta(int numero)
    {

        StartCoroutine(Validarresposta(numero)); 

    }

    //Co rotina para mostrar se acertou ou errou
    IEnumerator Validarresposta(int numero)
    {
        if (numero == alternativaCorreta[perguntaAtual])
        {
            imagemQuizz.color = Color.green;
            caixaDeEfeitos.PlayOneShot(efeitoAcerto);
        }
        else
        {
            imagemQuizz.color = Color.red;
            caixaDeEfeitos.PlayOneShot(efeitoErrado);
        }
        yield return new WaitForSeconds(2);

        imagemQuizz.color = Color.white;
        perguntaAtual++;
        if (perguntaAtual >= titulos.Length)
        {
            painelInicio.SetActive(true);
            painelJogo.SetActive(false);
            perguntaAtual = 0;
            caixaDeMusica.clip = musicaMenu;
            caixaDeMusica.Play();
        }
        else
        {
            ProximaPergunta(perguntaAtual);
        }

    }

}
