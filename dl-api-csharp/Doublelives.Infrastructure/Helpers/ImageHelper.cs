using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;

namespace Doublelives.Infrastructure.Helpers
{
    public static class ImageHelper
    {
        /// <summary>
        /// 调整图像大小并旋转图像，保持原始高宽比。 不处理原实例
        /// </summary>
        /// <param name="image">Image instance</param>
        /// <param name="width">desired width</param>
        /// <param name="height">desired height</param>
        /// <param name="rotateFlipType">desired RotateFlipType</param>
        /// <returns>new resized/rotated Image instance</returns>
        public static Image Resize(Image image, int width, int height, RotateFlipType rotateFlipType)
        {
            // 克隆Image实例，因为我们不想调整原始Image实例的大小
            var rotatedImage = image.Clone() as Image;
            rotatedImage.RotateFlip(rotateFlipType);
            var newSize = CalculateResizedDimensions(rotatedImage, width, height);

            var resizedImage = new Bitmap(newSize.Width, newSize.Height, PixelFormat.Format32bppArgb);
            resizedImage.SetResolution(72, 72);

            using (var graphics = Graphics.FromImage(resizedImage))
            {
                // 设置参数以创建高质量的缩略图
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.AntiAlias;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                // 使用图像属性以在调整大小后删除图像周围的黑色/灰色边框
                // （在白色图像上最明显），请参阅此帖子以获取更多信息：
                // http://www.codeproject.com/KB/GDI-plus/imgresizoutperfgdiplus.aspx
                using (var attribute = new ImageAttributes())
                {
                    attribute.SetWrapMode(WrapMode.TileFlipXY);

                    // 将调整大小的图像绘制到bitmap
                    graphics.DrawImage(rotatedImage, new Rectangle(new Point(0, 0), newSize), 0, 0, rotatedImage.Width,
                        rotatedImage.Height, GraphicsUnit.Pixel, attribute);
                }
            }

            return resizedImage;
        }

        /// <summary>
        /// 计算图像的调整大小尺寸，保留纵横比。
        /// </summary>
        /// <param name="image">Image instance</param>
        /// <param name="desiredWidth">所需的宽度</param>
        /// <param name="desiredHeight">所需的高度</param>
        /// <returns>具有调整大小的尺寸的大小实例</returns>
        private static Size CalculateResizedDimensions(Image image, int desiredWidth, int desiredHeight)
        {
            var widthScale = (double) desiredWidth / image.Width;
            var heightScale = (double) desiredHeight / image.Height;

            // 缩放到较小的比例，这适用于放大和缩小
            var scale = widthScale < heightScale ? widthScale : heightScale;

            return new Size
            {
                Width = (int) (scale * image.Width),
                Height = (int) (scale * image.Height)
            };
        }
    }
}