﻿// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Sprites/Overlay"
{
	Properties
	{
		[PerRendererData] _MainTex ("Sprite Texture", 2D) = "white" {}
	}

	SubShader
	{
		Tags
		{ 
			"Queue"="Transparent" 
			"IgnoreProjector"="True" 
			"RenderType"="Transparent" 
			"PreviewType"="Plane"
			"CanUseSpriteAtlas"="True"
		}

		Cull Off
		Lighting Off
		ZWrite Off
		Fog { Mode Off }
		Blend SrcAlpha OneMinusSrcAlpha

		Pass
		{
		CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma fragmentoption ARB_precision_hint_fastest
			#include "UnityCG.cginc"
			
			struct appdata_t
			{
				fixed4 vertex   : POSITION;
				fixed4 color    : COLOR;
				fixed2 texcoord : TEXCOORD0;
			};

			struct v2f
			{
				fixed4 vertex   : SV_POSITION;
				fixed4 color    : COLOR;
				fixed2 texcoord  : TEXCOORD0;
			};
			

			v2f vert(appdata_t IN)
			{
				v2f OUT;
				OUT.vertex = UnityObjectToClipPos(IN.vertex);
				OUT.texcoord = IN.texcoord;
				OUT.color = IN.color;

				return OUT;
			}

			sampler2D _MainTex;
			
			
			
			fixed4 frag(v2f IN) : COLOR
			{
				fixed4 output = 0;
				fixed4 inputA = tex2D(_MainTex, IN.texcoord);
				fixed4 inputB = IN.color;
				output = (inputA < 0.5) ? 2*inputA*inputB : 1-2*(1-inputA)*(1 - inputB);
				output.a = inputA.a*inputB.a;
				return output;
			}
		ENDCG
		}
	}
}