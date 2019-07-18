all : clean package
.PHONY : all

clean:
	rm -rf ./build
	rm -rf ./dist
	rm -rf ./itsme.egg-info

package: clean
	python3 setup.py sdist bdist_wheel
