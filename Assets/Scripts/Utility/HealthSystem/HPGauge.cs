using System;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
	[SerializeField] Slider _slider;
	[SerializeField] Image _fillArea;

	[Header("Threshold Rate of Color Change")]
	[SerializeField] float _cautionRate = 0.5f;
	[SerializeField] float _warningRate = 0.2f;

	[Header("Gauge Colors")]
	[SerializeField]
	Color _normalColor = new Color(98.0f / 255.0f, 242.0f / 255.0f, 105.0f / 255.0f);
	[SerializeField]
	Color _cautionColor = new Color(237.0f / 255.0f, 242.0f / 255.0f, 98.0f / 255.0f);
	[SerializeField]
	Color _warningColor = new Color(242.0f / 255.0f, 98.0f / 255.0f, 98.0f / 255.0f);

	float _maxHP = 100f;

	// You can initialize this script on Inspector.
	void Reset()
	{
		if (_slider == null)
			_slider = GetComponentInChildren<Slider>();

		_slider.maxValue = _maxHP;
		_slider.value = _maxHP;
	}


	public void ReflectOnSlider(float hp)
	{
		_slider.value = hp;
		float hpRate = hp / _maxHP;

		if (hpRate >= _cautionRate)
		{
			// Green
			_fillArea.color = _normalColor;
		}
		else if (_warningRate <= hpRate && hpRate < _cautionRate)
		{
			// Yellow
			_fillArea.color = _cautionColor;
		}
		else
		{
			// Red
			_fillArea.color = _warningColor;
		}
	}

	public void SetMaxHP(float maxHP)
	{
		_maxHP = maxHP;
		_slider.maxValue = _maxHP;
	}
}
