# 
import sys

from PIL import Image

images = [Image.open(x) for x in [r'common\examples\tools\1.1.jpg', r'common\examples\tools\2.1.jpg']]
widths, heights = zip(*(i.size for i in images))

total_width = sum(widths)
max_height = max(heights)

new_im = Image.new('RGB', (total_width, max_height))

x_offset = 0
for im in images:
  new_im.paste(im, (x_offset,0))
  x_offset += im.size[0]

new_im.save('result.jpg')