using System.Collections.Generic;

public class Solution {
    public bool IsNumber(string s) {
        var transfer = new Dictionary<State, Dictionary<CharType, State>>();
        var initialDictionary = new Dictionary<CharType, State> {
            {CharType.CHAR_NUMBER, State.STATE_INTEGER},
            {CharType.CHAR_POINT, State.STATE_POINT_WITHOUT_INT},
            {CharType.CHAR_SIGN, State.STATE_INT_SIGN}
        };
        transfer.Add(State.STATE_INITIAL, initialDictionary);
        var intSignDictionary = new Dictionary<CharType, State> {
            {CharType.CHAR_NUMBER, State.STATE_INTEGER},
            {CharType.CHAR_POINT, State.STATE_POINT_WITHOUT_INT}
        };
        transfer.Add(State.STATE_INT_SIGN, intSignDictionary);
        var integerDictionary = new Dictionary<CharType, State> {
            {CharType.CHAR_NUMBER, State.STATE_INTEGER},
            {CharType.CHAR_EXP, State.STATE_EXP},
            {CharType.CHAR_POINT, State.STATE_POINT}
        };
        transfer.Add(State.STATE_INTEGER, integerDictionary);
        var pointDictionary = new Dictionary<CharType, State> {
            {CharType.CHAR_NUMBER, State.STATE_FRACTION},
            {CharType.CHAR_EXP, State.STATE_EXP}
        };
        transfer.Add(State.STATE_POINT, pointDictionary);
        var pointWithoutIntDictionary = new Dictionary<CharType, State> {
            {CharType.CHAR_NUMBER, State.STATE_FRACTION}
        };
        transfer.Add(State.STATE_POINT_WITHOUT_INT, pointWithoutIntDictionary);
        var fractionDictionary = new Dictionary<CharType, State> {
            {CharType.CHAR_NUMBER, State.STATE_FRACTION},
            {CharType.CHAR_EXP, State.STATE_EXP}
        };
        transfer.Add(State.STATE_FRACTION, fractionDictionary);
        var expDictionary = new Dictionary<CharType, State> {
            {CharType.CHAR_NUMBER, State.STATE_EXP_NUMBER},
            {CharType.CHAR_SIGN, State.STATE_EXP_SIGN}
        };
        transfer.Add(State.STATE_EXP, expDictionary);
        var expSignDictionary = new Dictionary<CharType, State> {
            {CharType.CHAR_NUMBER, State.STATE_EXP_NUMBER}
        };
        transfer.Add(State.STATE_EXP_SIGN, expSignDictionary);
        var expNumberDictionary = new Dictionary<CharType, State> {
            {CharType.CHAR_NUMBER, State.STATE_EXP_NUMBER}
        };
        transfer.Add(State.STATE_EXP_NUMBER, expNumberDictionary);

        var length = s.Length;
        var state = State.STATE_INITIAL;

        for (var i = 0; i < length; i++) {
            var type = ToCharType(s[i]);
            if (!transfer[state].ContainsKey(type)) {
                return false;
            }
            else {
                state = transfer[state][type];
            }
        }

        return state == State.STATE_INTEGER || state == State.STATE_POINT || state == State.STATE_FRACTION ||
               state == State.STATE_EXP_NUMBER || state == State.STATE_END;
    }

    CharType ToCharType(char ch) {
        if (ch >= '0' && ch <= '9') {
            return CharType.CHAR_NUMBER;
        }
        else if (ch == 'e' || ch == 'E') {
            return CharType.CHAR_EXP;
        }
        else if (ch == '.') {
            return CharType.CHAR_POINT;
        }
        else if (ch == '+' || ch == '-') {
            return CharType.CHAR_SIGN;
        }
        else {
            return CharType.CHAR_ILLEGAL;
        }
    }

    enum State {
        STATE_INITIAL,
        STATE_INT_SIGN,
        STATE_INTEGER,
        STATE_POINT,
        STATE_POINT_WITHOUT_INT,
        STATE_FRACTION,
        STATE_EXP,
        STATE_EXP_SIGN,
        STATE_EXP_NUMBER,
        STATE_END
    }

    enum CharType {
        CHAR_NUMBER,
        CHAR_EXP,
        CHAR_POINT,
        CHAR_SIGN,
        CHAR_ILLEGAL
    }
}