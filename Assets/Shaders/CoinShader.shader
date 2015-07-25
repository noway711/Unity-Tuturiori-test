Shader "CoinShader" {
	Properties {
        _Color("Color & Transparency", Color) = (0, 0, 0, 0.5)
		_MainTex ("Base (RGB) Transparency(A)", 2D) = "white" {}
		_NothingTe ("Base (RGB) Transparency(A)", 2D) = "white" {}
    }
	SubShader {
		Pass {
			Lighting Off
			ZWrite Off
			Cull Off
			Blend SrcAlpha OneMinusSrcAlpha
			Tags {"Queue" = "Transparent"}        
			
			Material {
				Diffuse [_Color]
			}

			SetTexture [_MainTex] {
				constantColor [_Color]
				Combine texture, texture * constant
			}
		}
	}
 }