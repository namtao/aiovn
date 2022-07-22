#!/usr/bin/env python

'''
Stitching sample
================

Show how to use Stitcher API from python in a simple way to stitch panoramas
or scans.
'''

# Python 2/3 compatibility
from __future__ import print_function

import numpy as np
import cv2 as cv

import argparse
import sys

modes = (cv.Stitcher_PANORAMA, cv.Stitcher_SCANS)

# parser = argparse.ArgumentParser(prog='stitching.py', description='Stitching sample.')
# parser.add_argument('--mode',
#     type = int, choices = modes, default = cv.Stitcher_PANORAMA,
#     help = 'Determines configuration of stitcher. The default is `PANORAMA` (%d), '
#         'mode suitable for creating photo panoramas. Option `SCANS` (%d) is suitable '
#         'for stitching materials under affine transformation, such as scans.' % modes)
# parser.add_argument('--output', default = 'result.jpg',
#     help = 'Resulting image. The default is `result.jpg`.')
# parser.add_argument('img', nargs='+', help = 'input images')

# __doc__ += '\n' + parser.format_help()

def main(img):
    # args = parser.parse_args()

    # read input images
    imgs = []
    for img_name in img:
        img = cv.imread(cv.samples.findFile(img_name))
        if img is None:
            print("can't read image " + img_name)
            sys.exit(-1)
        imgs.append(img)

    stitcher = cv.Stitcher.create(cv.Stitcher_PANORAMA)
    status, pano = stitcher.stitch(imgs)

    if status != cv.Stitcher_OK:
        print("Can't stitch images, error code = %d" % status)
        sys.exit(-1)

    cv.imwrite(r'common\examples\tools\results.jpg', pano)
    # print("stitching completed successfully. %s saved!" % args.output)

    print('Done')


if __name__ == '__main__':
    # sys.argv[0] = [r"C:\Projects\Python\common\examples\tools\1.jpg", r"C:\Projects\Python\common\examples\tools\2.jpg", r"C:\Projects\Python\common\examples\tools\3.jpg"]
    main([r"C:\Projects\Python\common\examples\tools\1.jpg", r"C:\Projects\Python\common\examples\tools\2.jpg", r"C:\Projects\Python\common\examples\tools\3.jpg"])
    cv.destroyAllWindows()
