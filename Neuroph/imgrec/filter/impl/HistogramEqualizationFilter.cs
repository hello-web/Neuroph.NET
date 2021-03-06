﻿using System;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

namespace org.neuroph.imgrec.filter.impl
{


	/// <summary>
	/// Histogram equalization filter serves to reduce the contrast of the grayscale 
	/// image.For example, if the image before histogram equalization filter has too 
	/// many dark pixels and a little light pixels,after this filter the difference 
	/// will alleviate. If the plan is, after this filter, to use Otsu binarized filter, 
	/// this filter will not influence on him.
	/// 
	/// @author Mihailo Stupar
	/// </summary>
	[Serializable]
	public class HistogramEqualizationFilter : ImageFilter
	{

		[NonSerialized]
		private BufferedImage originalImage;
		[NonSerialized]
		private BufferedImage filteredImage;

		public virtual BufferedImage processImage(BufferedImage image)
		{

		originalImage = image;

		int width = originalImage.Width;
		int height = originalImage.Height;

		filteredImage = new BufferedImage(width, height, originalImage.Type);

		int[] histogram = imageHistogram(originalImage);

		int[] histogramCumulative = new int[histogram.Length];

		histogramCumulative[0] = histogram[0];
		for (int i = 1; i < histogramCumulative.Length; i++)
		{
				histogramCumulative[i] = histogramCumulative[i - 1] + histogram[i];
		}

		int G = 256;
		int gray;
		int alpha;

		int newColor;

		for (int i = 0; i < width; i++)
		{
				for (int j = 0; j < height; j++)
				{

			gray = (new Color(originalImage.getRGB(i, j))).Red;
			alpha = (new Color(originalImage.getRGB(i, j))).Alpha;

			newColor = (G - 1) * histogramCumulative[gray] / (width * height); //zaokruziti izbeci celobrojno deljenje


			newColor = ImageUtilities.colorToRGB(alpha, newColor, newColor, newColor);
			filteredImage.setRGB(i, j, newColor);
				}
		}

		return filteredImage;
		}


		public virtual int[] imageHistogram(BufferedImage image)
		{

		int[] histogram = new int[256];

		for (int i = 0; i < histogram.Length; i++)
		{
				histogram[i] = 0;
		}

		for (int i = 0; i < image.Width; i++)
		{
				for (int j = 0; j < image.Height; j++)
				{
			int gray = (new Color(image.getRGB(i, j))).Red;
			histogram[gray]++;
				}
		}

		return histogram;
		}
		public override string ToString()
		{
			return "Histogram Equalization Filter";
		}
	}

}