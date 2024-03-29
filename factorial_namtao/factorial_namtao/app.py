import streamlit as st
from factorial_namtao.factorial import fact

def main():
    st.title("Factorial Calculator")
    number = st.number_input("Enter a number: ", min_value=0, max_value= 100)
    
    if(st.button("Calculator")):
        result = fact(number)
        st.write(f'The factorial of {number} is {result}')
        st.balloons()
        
if __name__ == "__main__":
    main()