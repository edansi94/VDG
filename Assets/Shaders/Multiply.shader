Shader "Custom/Multiply" {
	Properties {
		_MainTex  ("Base (RGB)", 2D) = "white" {}
		_BlendTex ("Blend Texture", 2D) = "white" {}
		_Opacity  ("Blend Opacity", Range(0,1)) = 1
	}
	SubShader {
		Pass 
		{
			CGPROGRAM
			#pragma vertex vert_img
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"

			uniform sampler2D _MainTex;
			uniform sampler2D _BlendTex;
			fixed _Opacity;

			fixed4 frag(v2f_img i) : COLOR
			{
				fixed4 renderTex = tex2D(_MainTex, i.uv);
				fixed4 blendTex  = tex2D(_BlendTex, i.uv);

				fixed4 blendedMultiply = renderTex * blendTex;
				renderTex = lerp(renderTex, blendedMultiply, _Opacity);

				return renderTex;
			}
			ENDCG
		}
	}
	FallBack "Diffuse"
}
