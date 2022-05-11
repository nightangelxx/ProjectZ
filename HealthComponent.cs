using MLAPI;
using MLAPI.Messaging;
using MLAPI.NetworkVariable;
using UnityEngine;
using UnityEngine.UI;


public class HealthComponent : NetworkBehaviour
{
    public Text m_MyText;
    [SerializeField]
    private NetworkVariableInt m_Health = new NetworkVariableInt(100);

    public NetworkVariableInt Health => m_Health;

    void OnEnable()
    {
        // Subscribe for when Health value changes
        // This usually gets triggered when the server modifies that variable
        // and is later replicated down to clients
        // Подпишись на изменение значения здоровья
        // Обычно это срабатывает, когда сервер изменяет эту переменную
        // и позже передается клиентам
        Health.OnValueChanged += OnHealthChanged;
        m_MyText.text = m_Health.Value.ToString();
    }

    void OnDisable()
    {
        Health.OnValueChanged -= OnHealthChanged;
    }

    void OnHealthChanged(int oldValue, int newValue)
    {
        // Update UI, if this a client instance and it's the owner of the object
        // Обновляем UI, если это клиентский экземпляр и владелец объекта
        if (IsOwner && IsClient)
        {
            // TODO: Update UI code?
        }

        Debug.LogFormat("{0} has {1} health!", gameObject.name, m_Health.Value);
        m_MyText.text = m_Health.Value.ToString();
    }

    [ServerRpc]
    public void TakeDamageServerRpc(int amount)
    {
        // Health should be modified server-side only
        // Здоровье следует изменять только на стороне сервера
        if (!IsServer) return;
        Health.Value -= amount;

        // TODO: You can play a VFX/SFX here if needed
        // ЗАДАЧА: при необходимости вы можете воспроизвести здесь VFX / SFX

        if (Health.Value <= 0)
        {
            Health.Value = 0;
        }
    }
}
