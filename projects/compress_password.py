import pyminizip


def zip_with_pass(pdfPath, zipPath, password):
    pyminizip.compress(pdfPath, "", zipPath, password, 3)